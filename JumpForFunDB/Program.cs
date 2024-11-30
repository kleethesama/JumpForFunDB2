using JumpForFunDB;

// Tests for T-SQL queries and classes.

DatabaseManager testDB = new("JumpForFun");
testDB.CreateDataBaseAndTables();
DatabaseManager.RunSQLScript("DB-Create-AgeCheck-Trigger.sql");

// Creating manager for members and adding a member to database.

MemberManager memberManager = new(testDB);

Member testMember1 = new(null, "Bent", "Jensen", "+4564327172", "qwe@jumpforfun.com",
                        DateTime.Parse("05/04/2006"), DateTime.Today, "Roskilde");
memberManager.Add(testMember1);

Member testMember2 = new(null, "Bent", "Jensen", "+4592357834", "test@jumpforfun.com",
                        DateTime.Parse("05/04/2007"), DateTime.Today, "Roskilde");
memberManager.Add(testMember2);

// Testing if the Add call was a success by getting the member from the database again using candidate keys.

//Member? attempt1 = memberManager.GetById(100000);
//Tests.TestType1(attempt1);
//Console.WriteLine("\n" + attempt1);

//Member? attempt2 = memberManager.GetByEmail("qwe@jumpforfun.com");
//Tests.TestType1(attempt2);
//Console.WriteLine("\n" + attempt2);

//Member? attempt3 = memberManager.GetByPhoneNo("+4564327172");
//Tests.TestType1(attempt3);
//Console.WriteLine("\n" + attempt3);
