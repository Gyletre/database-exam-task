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
        Console.WriteLine("A to do task a");
        Console.WriteLine("B to do task b");
        Console.WriteLine("C to do task c");
        Console.WriteLine("D to do task d");
        Console.WriteLine("E to do task e");
        string? input = Console.ReadLine();
        MySqlDataReader reader = null;
        MySqlCommand cmd = con.CreateCommand();
        if (input == null) { return; }
        switch (input)
        {
            case "A":
                cmd.CommandText = "select name, phone from manager";
                reader = cmd.ExecuteReader();
                Console.WriteLine("name, phone number");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + ", " + reader.GetInt32(1));
                }
                break; 
            case "B":
                break;
            case "C":
                break;
            case "D":
                break;
            case "E":
                break;
            case "F":
                break;
            default:
                return;
        }
        
    }
}




