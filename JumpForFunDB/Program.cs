using JumpForFunDB;
using System.Diagnostics;

// Tests for T-SQL queries and classes.

DatabaseManager testDB = new("JumpForFun");
testDB.FirstTimeSetup();

// Creating manager for members and adding a member to database.

MemberManager memberManager = new(testDB);

Member testMember = new(null, "Bent", "Jensen", "+4564327172", "qwe@jumpforfun.com",
                        DateTime.Parse("05/04/1997"), DateTime.Today, "Roskilde");
memberManager.Add(testMember);

// Testing if the Add call was a success by getting the member from the database again.

int memberId = 100000;
Member member1 = memberManager.GetById(memberId) ?? throw new Exception($"The member with member id {memberId} was not found.");

Debug.Assert(member1.BookingId == null);
Debug.Assert(member1.FName == "Bent");
Debug.Assert(member1.LName == "Jensen");
Debug.Assert(member1.PhoneNo == "+4564327172");
Debug.Assert(member1.Email == "qwe@jumpforfun.com");
DateTime trueDate = new(1997, 4, 5);
Debug.Assert(member1.DateOfBirth.Date == trueDate.Date);
Debug.Assert(member1.CreationDate.Date == DateTime.Today);
Debug.Assert(member1.CenterLocation == "Roskilde");

Console.WriteLine("\n" + member1);