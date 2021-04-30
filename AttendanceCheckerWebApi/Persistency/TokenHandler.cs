using AttendanceCheckerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace AttendanceCheckerWebApi.Persistency
{
    public static class TokenHandler
    {

        public static List<AuthToken> authTokens = new List<AuthToken>();

        public static void addToken(AuthToken token)
        {
            authTokens.Add(token);
            Thread thread1 = new Thread(TokenHandler.waitAndDel);
            thread1.Start(token);

        }

         static void waitAndDel(object t)
        {            
            Thread.Sleep(20000);
            authTokens.Remove((AuthToken)t);
        }
    }
}
