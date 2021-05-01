﻿using System.Collections.Generic;
using System.Data;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.NonPlayable
{
    public record Fetch : IQuery<IEnumerable<NonPlayableCharacter>>
    {
        internal class Handler : Handler<Fetch, IEnumerable<NonPlayableCharacter>>
        {
            private const string Fetch = @"
select name
  from character
 where is_playable = false
 order by name";

            #region Public Interface

            public override IEnumerable<NonPlayableCharacter> MakeRequest(IDbConnection connection, Fetch query) =>
                connection.Query<NonPlayableCharacter>(Fetch);

            #endregion
        }
    }
}
