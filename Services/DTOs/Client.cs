using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class GetCloseMatchesRequest
    {
        public string Phonenumber { get; set; }
        public int Sensitivity { get; set; }
    }
    public class GetCloseMatchesResponse
    {
        public IEnumerable<string> Phonenumbers { get; set; }
    }
}
