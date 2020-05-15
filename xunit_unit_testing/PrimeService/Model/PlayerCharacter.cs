using System;

namespace PrimeService.Model
{
    public class PlayerCharacter
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime? DiedOn { get; set; }

        public string ContactInfo { get; private set; }

        public PlayerCharacter()
        {
            ContactInfo = GenerateContactInfo();
        }

        public PlayerCharacter(string fn, string ln, DateTime? diedOn = null) : base()
        {
            FirstName = (diedOn.HasValue ? "Late. " : "Mr. ") + fn;
            LastName = ln;
            DiedOn = diedOn;
        }

        private string GenerateContactInfo() => "67-45";
    }
}
