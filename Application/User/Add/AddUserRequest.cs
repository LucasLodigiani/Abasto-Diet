using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Add
{
        public record AddUserRequest : IRequest<(int, string)>
        {
            public string Password { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }

            public string PhoneNumber { get; set; }

        }
   
}
