using _11_March_Practical;
using _11_March_Practical.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;

try
{
    DataAccess dBaccess = new DataAccess();
    int a = 0;
    do
    {
        Console.WriteLine("\n*** Clinic Management System ***");
        Console.WriteLine("\tHey... Doctor!");
        Console.WriteLine("Please Enter your choice");
        Console.WriteLine("1. Enter Patient Details\n" +
            "2. View Patient Report (Single)\n" +   
            "3. View Patient Report (All)\n" +
            "4. Add Medical Information for existing Patient\n" +
            "5. View DailyReport\n" +
            "6. Clean the screen\n" +
            "7. Exit Program\n");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Patient patient = new Patient();
                MedicalInfo mdinfo = new MedicalInfo();
                DailyReport DR = new DailyReport();
                Console.WriteLine("Enter Patient Details");
                Console.WriteLine("Enter Patient ID");
                DR.PatientId = IsPositiveNumber();
                patient.PatientId = DR.PatientId;
                mdinfo.PatientId = DR.PatientId;
                Console.WriteLine("Enter Patient name");
                patient.PatientName = IsCorrectName();
                mdinfo.Patientname = patient.PatientName;
                Console.WriteLine("Enter Mobile No.");
                patient.MobileNo = IsCorrectMobileNum();
                Console.WriteLine("Enter Patient age");
                patient.Age = IsPositiveNumber();
                Console.WriteLine("Enter Weight in Kg");
                mdinfo.Weight = IsPositiveNumber();
                Console.WriteLine("Enter Blood Pressure");
                mdinfo.Bp = IsPositiveDouble();
                Console.WriteLine("Enter Cholestrol HDL");
                mdinfo.CholestrolHdl = IsPositiveDouble();
                Console.WriteLine("Enter Cholestrol LDL");
                mdinfo.CholestrolLdl = IsPositiveDouble();
                Console.WriteLine("Enter Sugar (Fast)");
                mdinfo.SugarFast = IsPositiveDouble();
                Console.WriteLine("Enter Sugar (Post Fast)");
                mdinfo.SugarPostFast = IsPositiveDouble();
                Console.WriteLine("Enter Medicines for Patient");
                mdinfo.Medicine = Console.ReadLine();
                Console.WriteLine("Appontment Date (Should be in the fromat YYYY-MM-DD)");
                mdinfo.AppointmentDate = Convert.ToDateTime(Console.ReadLine());
                DR.Date = mdinfo.AppointmentDate;
                Console.WriteLine("Enter Fees");
                DR.Fees = IsPositiveDouble();
                var newReport = await dBaccess.CreateReportAsync(DR);
                var newpatient = await dBaccess.CreatePatientAsync(patient);
                var newInfo = await dBaccess.CreateMDIndoAsync(mdinfo);
                Console.WriteLine("~~~ Patient Addeed Successfully ~~~");
                break;
            case 2:
                Console.WriteLine("Enter Patient ID to to Report");
                int ID = IsPositiveNumber(); 
                var getInfo = await dBaccess.GetAsync(ID);
                Console.WriteLine("ID  Name Wt BP C_HDL C_LDL S_F S_PF Medicines");
                Console.WriteLine($"{getInfo.PatientId} {getInfo.Patientname} {getInfo.Weight} {getInfo.Bp} {getInfo.CholestrolHdl} {getInfo.CholestrolLdl} {getInfo.SugarFast} {getInfo.SugarPostFast} {getInfo.Medicine}");
                break;
            case 3:
                var getAll = await dBaccess.GetAsync();
                Console.WriteLine("ID  Name Wt BP C_HDL C_LDL S_F S_PF Medicines   Date");
                foreach (var m in getAll)
                {
                    Console.WriteLine($" {m.PatientId} {m.Patientname} {m.Weight} {m.Bp} {m.CholestrolHdl} {m.CholestrolLdl} {m.SugarFast} {m.SugarPostFast} {m.Medicine}  {m.AppointmentDate}");
                }
                break;
            case 4:
                MedicalInfo mInfo = new MedicalInfo();
                DailyReport dailyReport = new DailyReport();
                Console.WriteLine("Enter Patient Details");
                Console.WriteLine("Enter Patient ID");
                mInfo.PatientId = IsPositiveNumber();
                dailyReport.PatientId = mInfo.PatientId;
                Console.WriteLine("Enter Patient name");
                mInfo.Patientname = IsCorrectName();
                Console.WriteLine("Enter Weight in Kg");
                mInfo.Weight = IsPositiveNumber();
                Console.WriteLine("Enter Blood Pressure");
                mInfo.Bp = IsPositiveDouble();
                Console.WriteLine("Enter Cholestrol HDL");
                mInfo.CholestrolHdl = IsPositiveDouble();
                Console.WriteLine("Enter Cholestrol LDL");
                mInfo.CholestrolLdl = IsPositiveDouble();
                Console.WriteLine("Enter Sugar (Fast)");
                mInfo.SugarFast = IsPositiveDouble();
                Console.WriteLine("Enter Sugar (Post Fast)");
                mInfo.SugarPostFast = IsPositiveDouble();
                Console.WriteLine("Enter Medicines for Patient");
                mInfo.Medicine = Console.ReadLine();
                Console.WriteLine("Appontment Date (Should be in the fromat YYYY-MM-DD)");
                mInfo.AppointmentDate = Convert.ToDateTime(Console.ReadLine());
                dailyReport.Date = mInfo.AppointmentDate;
                Console.WriteLine("Enter Fees");
                double Fees = IsPositiveDouble();
                dailyReport.Fees = Fees - Fees * 0.15;
                var updateInfo = await dBaccess.CreateMDIndoAsync(mInfo);
                var updateReport = await dBaccess.CreateReportAsync(dailyReport);
                Console.WriteLine("Updated Successfully");
                break;
            case 5:
                dBaccess.DailyReport();
                break;
            case 6:
                Console.Clear();
                break;
            case 7:
                a++;
                break;
            default:
                Console.WriteLine("Please Enter Correct Choice Number\n");
                break;

        }
    } while (a == 0);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}




//Validations
static int IsPositiveNumber()
{
    int number = Convert.ToInt32(Console.ReadLine());
    int d = 0;
    do
    {
        try
        {
            if (number >= 0)
            {
                d = 0;
            }
            else
            {
                Console.WriteLine("Please enter a positive number");
                number = Convert.ToInt32(Console.ReadLine());
                d++;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (d > 0);
    return number;
}

static double IsPositiveDouble()
{
    double number = Convert.ToDouble(Console.ReadLine());
    int d = 0;
    do
    {
        try
        {
            if (number >= 0)
            {
                d = 0;
            }
            else
            {
                Console.WriteLine("Please enter a positive number");
                number = Convert.ToDouble(Console.ReadLine());
                d++;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (d > 0);
    return number;
}

static string IsCorrectName()
{
    string PatientName = Console.ReadLine();
    Regex re = new Regex("[A-Z][A-Za-z ]+[A-Za-z]$");
    int g = 0;
    do
    {
        if (re.IsMatch(PatientName))
        {
            g = 0;
        }
        else
        {
            Console.WriteLine("Please enter correct name");
            PatientName = Console.ReadLine();
            g++;
        }
    } while (g > 0);
    return PatientName;
}

static string IsCorrectMobileNum()
{
    string Mob = Console.ReadLine();
    Regex re = new Regex(@"^[0-9]{10}$");
    int g = 0;
    do
    {
        if (re.IsMatch(Mob))
        {
            g = 0;
        }
        else
        {
            Console.WriteLine("Please enter correct Mobile Number");
            Mob = Console.ReadLine();
            g++;
        }
    } while (g > 0);
    return Mob;
}


