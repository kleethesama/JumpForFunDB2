using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JumpForFunDB;

internal static class Tests
{
    public static void TestType1(Member testMember)
    {
        Debug.Assert(testMember.BookingId == null);
        Debug.Assert(testMember.FName == "Bent");
        Debug.Assert(testMember.LName == "Jensen");
        Debug.Assert(testMember.PhoneNo == "+4564327172");
        Debug.Assert(testMember.Email == "qwe@jumpforfun.com");
        DateTime trueDate = new(1997, 4, 5);
        Debug.Assert(testMember.DateOfBirth.Date == trueDate.Date);
        Debug.Assert(testMember.CreationDate.Date == DateTime.Today);
        Debug.Assert(testMember.CenterLocation == "Roskilde");
    }
}