using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpForFunDB
{
    public class Member
    {
        public int MemberId { get; }
        public int? BookingId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; }
        public DateTime CreationDate { get; }

        public Member(int memberId, int? bookingId, string fName, string lName, string phoneNo, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            MemberId = memberId;
            BookingId = bookingId;
            FName = fName;
            LName = lName;
            PhoneNo = phoneNo;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreationDate = creationDate;
        }

        public Member(int? bookingId, string fName, string lName, string phoneNo, string email, DateTime dateOfBirth, DateTime creationDate)
        {
            BookingId = bookingId;
            FName = fName;
            LName = lName;
            PhoneNo = phoneNo;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"Member id: {MemberId}, Booking id: {BookingId}, First name: {FName}, Last name: {LName}, " +
            $"Phone number: {PhoneNo}, Email: {Email}, Date of birth: {DateOfBirth}, Member sign-up date: {CreationDate}";
        }
    }
}
