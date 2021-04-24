﻿using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters
{
    public record Find(string Name) : IQuery<Character>
    {
        #region Nested Types

        internal class Handler : Handler<Find, Character>
        {
            private const string Find = @"
select name
  from character
 where name = @Name
";

            #region Public Interface

            public override Character MakeRequest(IDbConnection connection, Find query)
            {
                return connection.QuerySingle<Character>(Find, query);
            }

            #endregion
        }

        #endregion
    }
}