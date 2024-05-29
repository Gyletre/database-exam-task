using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;


Behavior program = new Behavior();
while(true)
{
    if (program.con.State == System.Data.ConnectionState.Closed)
    {
        Console.WriteLine("C to connect to DB");
    }
    else if (program.con.State == System.Data.ConnectionState.Open)
    {
        Console.WriteLine("D to disconnect from DB");
        Console.WriteLine("T to do tasks");
    }
    
    Console.WriteLine("E to exit");
    string? input = Console.ReadLine();
    if (input != null)
    {
        bool exit = program.Command(input);
        if (exit)
        {
            break;
        }
    }
}
public class Behavior
{
    public MySqlConnection con;
    public Behavior()
    {
        con = new MySqlConnection("Server=localhost; Database=PT; Uid=root; Pwd=1234");
        
    }
    public bool Command(string input)
    {
        if (input == null) { return false; }
        switch(input)
        {
            case "C":
                try
                {
                    con.Open();
                    Console.WriteLine("connection successful");
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                break;
            case "D":
                try
                {
                    
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                break;
            case "T":
                TaskManager();
                break;
            case "E":
                con.Close();
                return true;
            default: 
                Console.WriteLine("No");
                break;
        }
        return false;
            
        
        
    }
    private void TaskManager()
    {
        Console.WriteLine("\nA to do task a)");
        Console.WriteLine("B to do task b)");
        Console.WriteLine("C to do task c)");
        Console.WriteLine("D to do task d)");
        Console.WriteLine("E to do task e)");
        Console.WriteLine("F to do task f)");
        Console.WriteLine("G to do task g)");
        Console.WriteLine("H to do task h)");
        Console.WriteLine("I to do task i)");
        Console.WriteLine("J to do task j)");
        Console.WriteLine("K to do task k)");
        Console.WriteLine("L to do task l)");
        Console.WriteLine("M to do task m)");
        Console.WriteLine("N to do task n)");
        Console.WriteLine("O to do task o)");
        Console.WriteLine("P to do task p)");
        Console.WriteLine("Q to do task q)");
        Console.WriteLine("R to do task r)");
        Console.WriteLine("S to do task s)");
        Console.WriteLine("T to do task t)\n");
        string? input = Console.ReadLine();
        MySqlDataReader? reader = null;
        MySqlCommand cmd = con.CreateCommand();
        if (input == null) { return; }
        switch (input)
        {
            case "A":
                cmd.CommandText = "select name, phone from manager";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Name and phone number of all managers");
                Console.WriteLine("name, phone number");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1));
                }
                break;
            case "B":
                cmd.CommandText = "SELECT driver.name FROM driver, office WHERE office.id = driver.office_id AND office.city = 'Grimstad' AND driver.gender = 'F'";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Name of all female drivers in Grimstad");
                Console.WriteLine("name");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
                break;
            case "C": 
                cmd.CommandText = "SELECT city, 1+sum(amount) FROM (SELECT office.city as city, count(admin.id) as amount FROM office, admin WHERE office.id = admin.office_id GROUP BY office.id UNION ALL SELECT office.city as city, count(driver.id) as amount FROM office, driver WHERE office.id = driver.office_id GROUP BY office.id) tablee GROUP BY city";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Total amount of employees in each office");
                Console.WriteLine("office, count");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1));
                }
                break;
            case "D":
                cmd.CommandText = "SELECT car.manufacturer, car.model, car.reg_plate FROM car, office where office.id = car.office_id AND office.city = 'Grimstad'";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Car info of all cars in Grimstad");
                Console.WriteLine("manufacturer, model, registration plate");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) +", "+ reader.GetString(1) +", "+ reader.GetString(2));
                }
                break;
            case "E":
                cmd.CommandText = "SELECT count(*) FROM car WHERE reg_plate LIKE 'PD%'";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Cars with PD on plate");
                Console.WriteLine("count(*)");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "F":
                cmd.CommandText = "SELECT carID, COUNT(DISTINCT driveID) FROM (SELECT car.id AS carID, driver.id as driveID FROM car, `Private Job`, driver WHERE (car.id = `Private Job`.car_id AND driver.id = `Private Job`.driver_id) UNION ALL SELECT car.id AS carID, driver.id as driveID FROM car, `Business Job`, driver WHERE (car.id = `Business Job`.car_id AND driver.id = `Business Job`.driver_id)) carDrivers GROUP BY carID ORDER BY carID";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Total amount of drivers per car");
                Console.WriteLine("car id, amount");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
                }
                break;
            case "G":
                cmd.CommandText = "SELECT `Car Owner`.name, `Car Owner`.phone, count(car.id) FROM `Car Owner`, car WHERE car.car_owner_id = `Car Owner`.id GROUP BY `Car Owner`.id HAVING count(car.id)>1";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Car owners owning more than one car");
                Console.WriteLine("car owner name, car owner phone, car amount");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1) + ", " + reader.GetInt32(2));
                }
                break;
            case "H":
                cmd.CommandText = "SELECT `Business Client`.name, `Business Client`.address FROM `Business Client`";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Full address of every Business Client");
                Console.WriteLine("name, address");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetString(1));
                }
                break;
            case "I":
                cmd.CommandText = "SELECT office.city, `Business Client`.name, `Business Contract`.number_of_jobs, `Business Contract`.fee FROM `Business Contract`, office, `Business Client` WHERE status = \"Active\" AND office.id = `Business Contract`.office_id AND `Business Client`.id = `Business Contract`.client_id";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Contract info of currently active contracts");
                Console.WriteLine("Office, client name, jobs in contract, price");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetInt32(2) + ", " + reader.GetInt32(3));
                }
                break;
            case "J":
                cmd.CommandText = "SELECT office.city, COUNT(DISTINCT `Private Client`.id) FROM office, `Private Job`, `Private Client`, driver WHERE driver.id = `Private Job`.driver_id AND `Private Job`.client_id = `Private Client`.id AND driver.office_id = office.id GROUP BY office.id";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Total amount of private clients per office");
                Console.WriteLine("Office, amount");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1));
                }
                break;
            case "K":
                cmd.CommandText = "SELECT dName, time, type, pick_up, drop_off, status FROM (SELECT driver.name as dName, `Private Job`.time as time,  `Private Job`.status as status, \"private\" as type, `Private Job`.pick_up_adr as pick_up, `Private Job`.drop_off_adr as drop_off FROM driver, `Private Job` WHERE driver.id = `Private Job`.driver_id UNION ALL SELECT driver.name as dName, `Business Job`.time as time,  `Business Job`.status as status, \"business\" as type, `Business Job`.pick_up_adr as pick_up, `Business Job`.drop_off_adr as drop_off FROM driver, `Business Job` WHERE driver.id = `Business Job`.driver_id ) driverJobs WHERE time LIKE @date ORDER BY time";
                Console.WriteLine("Write wanted date (yyyy-mm-dd)");
                string searchDate = Console.ReadLine()+"%";
                
                if (searchDate == "%") { break; }
                cmd.Parameters.AddWithValue("@date", searchDate);
                reader = cmd.ExecuteReader();

                Console.WriteLine("Details of jobs of ##ENTER MR MAN DRIVER HERE## on a given date");
                Console.WriteLine("Driver name, time, type, pick up location, drop off location, status");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetString(3) + ", " + reader.GetString(4) + ", " + reader.GetString(5));
                }
                break;
            case "L":
                cmd.CommandText = "SELECT driver.name FROM driver WHERE age > 55";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Drivers over 55 years in age");
                Console.WriteLine("Driver name");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
                break;
            case "M":
                cmd.CommandText = "SELECT `Private Client`.name, `Private Client`.phone FROM `Private Client`, `Private Job` WHERE `Private Client`.id = `Private Job`.client_id AND `Private Job`.time LIKE \"2020-11%\" AND `Private Job`.status LIKE \"Completed%\"";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Private Customers who ordered in november 2020");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1));
                }
                break;
            case "N":
                cmd.CommandText = "SELECT `Private Client`.name, `Private Client`.address, COUNT(*) FROM `Private Client`, `Private Job` WHERE `Private Client`.id = `Private Job`.client_id GROUP BY `Private Client`.id HAVING COUNT(*) > 3";
                reader = cmd.ExecuteReader();
                Console.WriteLine("Client name, client address, times ordered taxi");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetUInt32(2));
                }
                break;
            case "O":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "P":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "Q":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "R":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "S":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;
            case "T":
                cmd.CommandText = "SELECT office.id FROM office";
                reader = cmd.ExecuteReader();
                Console.WriteLine("total cars");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                break;

            default:
                return;
        }
        reader.Close();
    }
}




