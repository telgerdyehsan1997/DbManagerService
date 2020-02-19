using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Enums
{
    public enum PasswordVerificationResult
    {
        Success,
        Failed,
        SuccessRehashNeeded
    }
}
