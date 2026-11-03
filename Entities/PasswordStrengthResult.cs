using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PasswordStrengthResult
    {
        
            public int Score { get; set; }

            public string Message { get; set; } = "";

            public string? Warning { get; set; }

            public IList<string>? Suggestions { get; set; }
        
    }
}
