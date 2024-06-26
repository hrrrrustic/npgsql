﻿using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Npgsql.Util;

namespace Npgsql.Internal;

/// <summary>
/// A factory which get generate instances of <see cref="NpgsqlDatabaseInfo"/>, which describe a database
/// and the types it contains. When first connecting to a database, Npgsql will attempt to load information
/// about it via this factory.
/// </summary>
[Experimental(NpgsqlDiagnostics.ConvertersExperimental)]
public interface INpgsqlDatabaseInfoFactory
{
    /// <summary>
    /// Given a connection, loads all necessary information about the connected database, e.g. its types.
    /// A factory should only handle the exact database type it was meant for, and return null otherwise.
    /// </summary>
    /// <returns>
    /// An object describing the database to which <paramref name="conn"/> is connected, or null if the
    /// database isn't of the correct type and isn't handled by this factory.
    /// </returns>
    Task<NpgsqlDatabaseInfo?> Load(NpgsqlConnector conn, NpgsqlTimeout timeout, bool async);
}
