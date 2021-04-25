﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read.Characters.Playable
{
    public record Fetch : IQuery<IEnumerable<PlayableCharacter>>
    {
        internal class Handler : Handler<Fetch, IEnumerable<PlayableCharacter>>
        {
            #region Public Interface

            public override IEnumerable<PlayableCharacter> MakeRequest(IDbConnection connection, Fetch query)
            {
                return connection
                    .Query<Record>(Record.Fetch)
                    .Select(Record.AsPlayableCharacter);
            }

            #endregion
        }
    }
}
