using Microsoft.Data.SqlClient;
namespace JumpForFunDB
{
    internal class MemberManager
    {
        public DatabaseManager DatabaseManager { get; set; }

        public MemberManager(DatabaseManager dbManager)
        {
            DatabaseManager = dbManager;
        }

        public void Add(Member member)
        {
            using (SqlConnection conn = new($"Server=localhost;Integrated Security=True;database={DatabaseManager.DatabaseName};Encrypt=False"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO MEMBER (FName, LName, PhoneNo, Email, DateOfBirth, CreationDate, CenterLocation) " +
                                   "VALUES (@FName, @LName, @PhoneNo, @Email, @DateOfBirth, @CreationDate, @CenterLocation)";
                    SqlCommand command = new(query, conn);
                    command.Parameters.AddWithValue("@FName", member.FName);
                    command.Parameters.AddWithValue("@LName", member.LName);
                    command.Parameters.AddWithValue("@PhoneNo", member.PhoneNo);
                    command.Parameters.AddWithValue("@Email", member.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", member.DateOfBirth);
                    command.Parameters.AddWithValue("@CreationDate", member.CreationDate);
                    command.Parameters.AddWithValue("@CenterLocation", member.CenterLocation);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Data has been successfully added!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Member Get(int memberId)
        {
            Member member = null;
            using (SqlConnection myConn = new(DatabaseManager.Connection))
            {
                try
                {
                    myConn.Open();
                    string query = "SELECT MemberId, BookingId, FName, LName, " +
                                   "PhoneNo, Email, DateOfBirth, CreationDate, CenterLocation FROM Members";
                    SqlCommand command = new(query, myConn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == memberId)
                            {
                                member = new Member(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                                    reader.GetDateTime(6), reader.GetDateTime(7), reader.GetString(8));
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return member;
        }

        public List<Member> GetAllMembers()
        {
            List<Member> members = [];
            using (SqlConnection myConn = new(DatabaseManager.Connection))
            {
                try
                {
                    myConn.Open();
                    string query = "SELECT MemberId, BookingId, FName, LName, " +
                                   "PhoneNo, Email, DateOfBirth, CreationDate, CenterLocation FROM Members";
                    SqlCommand command = new(query, myConn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Member member = new(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                                reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                                reader.GetDateTime(6), reader.GetDateTime(7), reader.GetString(8));
                            members.Add(member);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return members;
        }
    }
}
