using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birth { get; set; }
        public Department Department { get; set; }
        public byte[] Image { get; set; }
        public string Created { get; set; }
    }
    public enum Department
    {
        Mathematics, Physics, Chemistry, Informatics
    }
}
