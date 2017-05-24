using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Maid.Context.Repository;

namespace Maid.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public UserController(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        // POST api/values
        [HttpPost]
        public UserData Login([FromBody]LoginPar value)
        {
            var userRole = _userRoleRepository.Single(u => u.User.LoginId == value.LoginId || u.User.Mobile == value.LoginId || u.User.Email == value.LoginId
                , r => r.Role, r => r.User);
            if (userRole.User.Pwd == value.Pwd)
            {
                return new UserData() { ID = userRole.User.Id, Name = userRole.User.LoginId, Role = userRole.Role.Name };
            }
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserData Get(int id)
        {
            var user = _userRepository.Single(u => u.Id == id);

            return new UserData() { ID = user.Id, Name = user.LoginId };
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]LoginPar value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class UserData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
        }
        public class LoginPar
        {
            public string LoginId { get; set; }
            public string Pwd { get; set; }
        }
    }
}
