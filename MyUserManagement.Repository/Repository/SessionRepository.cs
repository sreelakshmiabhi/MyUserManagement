using Microsoft.AspNetCore.Http;
using MyUserManagement.Data.Model;
using MyUserManagement.Repository.Interface;
using MyUserManagement.Repository.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUserManagement.Repository.Repository
{
    public class SessionRepository : ISessionRepository
    {       
        private readonly ISession _session;
        
        public SessionRepository(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;      

        }
        public void SetSession(List<UserModel> model)
        {
            SetObjectAsJson(SessionKeys.UserSessionKey, model);           
        }
      
        public List<UserModel> GetSession()
        {
            List<UserModel> luse = new List<UserModel>();
            return GetObjectFromJson<List<UserModel>>(SessionKeys.UserSessionKey);

        }
        public T GetObjectFromJson<T>(string key)
        {
            var value = _session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
        private void SetObjectAsJson(string key, Object value)
        {
            _session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
