﻿// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace SqlParser;

internal static class Keywords
{
    /// <summary>
    /// Builds a list of SQL keywords from the enumeration
    /// </summary>
    static Keywords()
    {
        var renamedKeywords = new Dictionary<string, string>
        {
            {"END_EXEC", "END-EXEC"}
        };
        var keywords = Enum.GetNames<Keyword>()
                .Where(n => n != nameof(Keyword.undefined))
                .ToArray();

        foreach (var renamed in renamedKeywords)
        {
            var index = Array.FindIndex(keywords, k => k == renamed.Key);
            if (index > -1)
            {
                keywords[index] = renamed.Value;
            }
        }

        All = [.. keywords];
    }

    internal static readonly string[] All;

    /// These keywords can't be used as a table alias, so that `FROM table_name alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForColumnAlias = [
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        Keyword.RETURNING,
        // Reserved only as a column alias in the `SELECT` clause
        Keyword.FROM,
        Keyword.INTO,
        Keyword.END,
    ];

    /// Can't be used as a column alias, so that `SELECT Expression alias`
    /// can be parsed unambiguously without looking ahead.
    internal static readonly Keyword[] ReservedForTableAlias =
    [
        // Reserved as both a table and a column alias:
        Keyword.WITH,
        Keyword.EXPLAIN,
        Keyword.ANALYZE,
        Keyword.SELECT,
        Keyword.WHERE,
        Keyword.GROUP,
        Keyword.SORT,
        Keyword.HAVING,
        Keyword.ORDER,
        Keyword.PIVOT,
        Keyword.UNPIVOT,
        Keyword.TOP,
        Keyword.LATERAL,
        Keyword.VIEW,
        Keyword.LIMIT,
        Keyword.OFFSET,
        Keyword.FETCH,
        Keyword.UNION,
        Keyword.EXCEPT,
        Keyword.INTERSECT,
        // Reserved only as a table alias in the `FROM`/`JOIN` clauses:
        Keyword.ON,
        Keyword.JOIN,
        Keyword.INNER,
        Keyword.CROSS,
        Keyword.FULL,
        Keyword.LEFT,
        Keyword.RIGHT,
        Keyword.NATURAL,
        Keyword.USING,
        Keyword.CLUSTER,
        Keyword.DISTRIBUTE,
        Keyword.GLOBAL,
        // for MSSQL-specific OUTER APPLY (seems reserved in most dialects)
        Keyword.OUTER,
        Keyword.SET,
        Keyword.QUALIFY,
        Keyword.WINDOW,
        Keyword.END,
        Keyword.FOR,
        // for MYSQL PARTITION SELECTION
        Keyword.PARTITION,
        Keyword.PREWHERE,
        Keyword.SETTINGS,
        Keyword.FORMAT,
        // for Snowflake START WITH .. CONNECT BY
        Keyword.START,
        Keyword.CONNECT,
        Keyword.AS, // TODO remove?
        // Reserved for snowflake MATCH_RECOGNIZE
        Keyword.MATCH_RECOGNIZE,
    ];
}

// ReSharper disable InconsistentNaming
public enum Keyword
{
    ABORT,
    ABS,
    ABSOLUTE,
    ACCESS,
    ACTION,
    ADD,
    ADMIN,
    AFTER,
    AGAINST,
    AGGREGATION,
    ALIAS,
    ALL,
    ALLOCATE,
    ALTER,
    ALWAYS,
    ANALYZE,
    AND,
    ANTI,
    ANY,
    APPLY,
    ARCHIVE,
    ARE,
    ARRAY,
    ARRAY_MAX_CARDINALITY,
    AS,
    ASC,
    ASENSITIVE,
    ASOF,
    ASSERT,
    ASYMMETRIC,
    AT,
    ATOMIC,
    ATTACH,
    AUTHORIZATION,
    AUTO,
    AUTO_INCREMENT,
    AUTOINCREMENT,
    AVG,
    AVRO,
    BACKWARD,
    BASE64,
    BEFORE,
    BEGIN,
    BEGIN_FRAME,
    BEGIN_PARTITION,
    BETWEEN,
    BIGINT,
    BIGNUMERIC,
    BINARY,
    BINDING,
    BLOB,
    BOOL,
    BOOLEAN,
    BOTH,
    BROWSE,
    BTREE,
    BY,
    BYPASSRLS,
    BYTEA,
    BYTES,
    CACHE,
    CALL,
    CALLED,
    CARDINALITY,
    CASCADE,
    CASCADED,
    CASE,
    CAST,
    CEIL,
    CEILING,
    CENTURY,
    CHAIN,
    CHANGE,
    CHANGE_TRACKING,
    CHANNEL,
    CHAR,
    CHAR_LENGTH,
    CHARACTER,
    CHARACTER_LENGTH,
    CHARACTERS,
    CHARSET,
    CHECK,
    CLOB,
    CLONE,
    CLOSE,
    CLUSTER,
    COALESCE,
    COLLATE,
    COLLATION,
    COLLECT,
    COLLECTION,
    COLUMN,
    COLUMNS,
    COMMENT,
    COMMIT,
    COMMITTED,
    COMPRESSION,
    COMPUTE,
    CONCURRENTLY,
    CONDITION,
    CONFLICT,
    CONNECT,
    CONNECTION,
    CONSTRAINT,
    CONTAINS,
    CONVERT,
    COPY,
    COPY_OPTIONS,
    CORR,
    CORRESPONDING,
    COUNT,
    COVAR_POP,
    COVAR_SAMP,
    CREATE,
    CREATEDB,
    CREATEROLE,
    CREDENTIALS,
    CROSS,
    CSV,
    CUBE,
    CUME_DIST,
    CURRENT,
    CURRENT_CATALOG,
    CURRENT_DATE,
    CURRENT_DEFAULT_TRANSFORM_GROUP,
    CURRENT_PATH,
    CURRENT_ROLE,
    CURRENT_ROW,
    CURRENT_SCHEMA,
    CURRENT_TIME,
    CURRENT_TIMESTAMP,
    CURRENT_TRANSFORM_GROUP_FOR_TYPE,
    CURRENT_USER,
    CURSOR,
    CYCLE,
    DATA,
    DATABASE,
    DATA_RETENTION_TIME_IN_DAYS,
    DATE,
    DATE32,
    DATETIME,
    DATETIME64,
    DAY,
    DAYOFWEEK,
    DAYOFYEAR,
    DEALLOCATE,
    DEC,
    DECADE,
    DECIMAL,
    DECLARE,
    DEDUPLICATE,
    DEFAULT,
    DEFAULT_DDL_COLLATION,
    DEFERRABLE,
    DEFERRED,
    DEFINE,
    DEFINED,
    DELAYED,
    DELETE,
    DELIMITED,
    DELIMITER,
    DENSE_RANK,
    DEREF,
    DESC,
    DESCRIBE,
    DETACH,
    DETERMINISTIC,
    DIRECTORY,
    DISABLE,
    DISCARD,
    DISCONNECT,
    DISTINCT,
    DISTRIBUTE,
    DIV,
    DO,
    DOUBLE,
    DOW,
    DOY,
    DROP,
    DUPLICATE,
    DYNAMIC,
    EACH,
    ELEMENT,
    ELEMENTS,
    ELSE,
    EMPTY,
    ENABLE,
    ENABLE_SCHEMA_EVOLUTION,
    ENCODING,
    ENCRYPTION,
    END,
    END_FRAME,
    END_PARTITION,
    ENFORCED,
    END_EXEC,
    ENDPOINT,
    ENGINE,
    ENUM,
    EPHEMERAL,
    EPOCH,
    EQUALS,
    ERROR,
    ESCAPE,
    ESCAPED,
    EVENT,
    EVERY,
    EXCEPT,
    EXCEPTION,
    EXCLUDE,
    EXCLUSIVE,
    EXEC,
    EXECUTE,
    EXISTS,
    EXP,
    EXPANSION,
    EXPLAIN,
    EXPLICIT,
    EXPORT,
    EXTENDED,
    EXTENSION,
    EXTERNAL,
    EXTRACT,
    FAIL,
    FALSE,
    FETCH,
    FIELDS,
    FILE,
    FILES,
    FILE_FORMAT,
    FILL,
    FILTER,
    FINAL,
    FIRST,
    FIRST_VALUE,
    FIXEDSTRING,
    FLOAT,
    FLOAT32,
    FLOAT4,
    FLOAT64,
    FLOAT8,
    FLOOR,
    FLUSH,
    FOLLOWING,
    FOR,
    FORCE,
    FORCE_NOT_NULL,
    FORCE_NULL,
    FORCE_QUOTE,
    FOREIGN,
    FORMAT,
    FORMATTED,
    FORWARD,
    FRAME_ROW,
    FREE,
    FREEZE,
    FROM,
    FULL,
    FULLTEXT,
    FUNCTION,
    FUNCTIONS,
    FUSION,
    GENERAL,
    GENERATED,
    GEOGRAPHY,
    GET,
    GLOBAL,
    GRANT,
    GRANTED,
    GRANTS,
    GRAPHVIZ,
    GROUP,
    GROUPING,
    GROUPS,
    HASH,
    HAVING,
    HEADER,
    HIGH_PRIORITY,
    HIVEVAR,
    HOLD,
    HOSTS,
    HOUR,
    ID,
    IDENTITY,
    IF,
    IGNORE,
    ILIKE,
    IMMEDIATE,
    IMMUTABLE,
    IN,
    INCLUDE,
    INCLUDE_NULL_VALUES,
    INCREMENT,
    INDEX,
    INDICATOR,
    INHERIT,
    INITIALLY,
    INNER,
    INOUT,
    INPUT,
    INPUTFORMAT,
    INSENSITIVE,
    INSERT,
    INSTALL,
    INSTEAD,
    INT,
    INT128,
    INT16,
    INT2,
    INT256,
    INT32,
    INT4,
    INT64,
    INT8,
    INTEGER,
    INTERPOLATE,
    INTERSECT,
    INTERSECTION,
    INTERVAL,
    INTO,
    IS,
    ISODOW,
    ISOLATION,
    ISOWEEK,
    ISOYEAR,
    ITEMS,
    JAR,
    JOIN,
    JSON,
    JSONB,
    JSONFILE,
    JSON_TABLE,
    JULIAN,
    KEY,
    KEYS,
    KILL,
    LAG,
    LANGUAGE,
    LARGE,
    LAST,
    LAST_VALUE,
    LATERAL,
    LEAD,
    LEADING,
    LEFT,
    LEVEL,
    LIKE,
    LIKE_REGEX,
    LIMIT,
    LINES,
    LISTAGG,
    LN,
    LOAD,
    LOCAL,
    LOCALTIME,
    LOCALTIMESTAMP,
    LOCATION,
    LOCK,
    LOCKED,
    LOGIN,
    LOGS,
    LOWCARDINALITY,
    LOWER,
    LOW_PRIORITY,
    MACRO,
    MANAGEDLOCATION,
    MAP,
    MATCH,
    MATCHED,
    MATCHES,
    MATCH_CONDITION,
    MATCH_RECOGNIZE,
    MATERIALIZED,
    MAX,
    MAXVALUE,
    MAX_DATA_EXTENSION_TIME_IN_DAYS,
    MEASURES,
    MEDIUMINT,
    MEMBER,
    MERGE,
    METADATA,
    METHOD,
    MICROSECOND,
    MICROSECONDS,
    MILLENIUM,
    MILLENNIUM,
    MILLISECOND,
    MILLISECONDS,
    MIN,
    MINUTE,
    MINVALUE,
    MOD,
    MODE,
    MODIFIES,
    MODIFY,
    MODULE,
    MONTH,
    MSCK,
    MULTISET,
    MUTATION,
    NAME,
    NANOSECOND,
    NANOSECONDS,
    NATIONAL,
    NATURAL,
    NCHAR,
    NCLOB,
    NESTED,
    NEW,
    NEXT,
    NO,
    NOBYPASSRLS,
    NOCREATEDB,
    NOCREATEROLE,
    NOINHERIT,
    NOLOGIN,
    NONE,
    NOREPLICATION,
    NORMALIZE,
    NOSCAN,
    NOSUPERUSER,
    NOT,
    NOTHING,
    NOWAIT,
    NO_WRITE_TO_BINLOG,
    NTH_VALUE,
    NTILE,
    NULL,
    NULLABLE,
    NULLIF,
    NULLS,
    NUMERIC,
    NVARCHAR,
    OBJECT,
    OCCURRENCES_REGEX,
    OCTET_LENGTH,
    OCTETS,
    OF,
    OFFSET,
    OLD,
    OMIT,
    ON,
    ONE,
    ONLY,
    OPEN,
    OPERATOR,
    OPTIMIZE,
    OPTIMIZER_COSTS,
    OPTION,
    OPTIONS,
    OR,
    ORC,
    ORDER,
    ORDINALITY,
    OUT,
    OUTER,
    OUTPUTFORMAT,
    OVER,
    OVERFLOW,
    OVERLAPS,
    OVERLAY,
    OVERWRITE,
    OWNED,
    OWNER,
    PARALLEL,
    PARAMETER,
    PARQUET,
    PART,
    PARTITION,
    PARTITIONED,
    PARTITIONS,
    PASSWORD,
    PAST,
    PATH,
    PATTERN,
    PER,
    PERCENT,
    PERCENT_RANK,
    PERCENTILE_CONT,
    PERCENTILE_DISC,
    PERIOD,
    PERSISTENT,
    PIVOT,
    PLACING,
    PLANS,
    POLICY,
    PORTION,
    POSITION,
    POSITION_REGEX,
    POWER,
    PRAGMA, 
    PRECEDES,
    PRECEDING,
    PRECISION,
    PREPARE,
    PRESERVE,
    PREWHERE,
    PRIMARY,
    PRIOR,
    PRIVILEGES,
    PROCEDURE,
    PROGRAM,
    PURGE,
    QUALIFY,
    QUARTER,
    QUERY,
    QUOTE,
    RANGE,
    RANK,
    RAW,
    RCFILE,
    READ,
    READ_ONLY,
    READS,
    REAL,
    RECURSIVE,
    REF,
    REFERENCES,
    REFERENCING,
    REGCLASS,
    REGEXP,
    REGR_AVGX,
    REGR_AVGY,
    REGR_COUNT,
    REGR_INTERCEPT,
    REGR_R2,
    REGR_SLOPE,
    REGR_SXX,
    REGR_SXY,
    REGR_SYY,
    RELATIVE,
    RELAY,
    RELEASE,
    REMOTE,
    RENAME,
    REPAIR,
    REPEATABLE,
    REPLACE,
    REPLICA,
    REPLICATION,
    RESET,
    RESPECT,
    RESTRICT,
    RESTRICTED,
    RESULT,
    RESULTSET,
    RETURN,
    RETURNING,
    RETURNS,
    REVOKE,
    RIGHT,
    RLIKE,
    ROLE,
    ROLLBACK,
    ROLLUP,
    ROOT,
    ROW,
    ROW_NUMBER,
    RULE,
    ROWID,
    ROWS,
    SAFE,
    SAFE_CAST,
    SAVEPOINT,
    SCHEMA,
    SCOPE,
    SCROLL,
    SEARCH,
    SECOND,
    SECRET,
    SECURITY,
    SELECT,
    SEMI,
    SENSITIVE,
    SEPARATOR,
    SEQUENCE,
    SEQUENCEFILE,
    SEQUENCES,
    SERDE,
    SERDEPROPERTIES,
    SERIALIZABLE,
    SESSION,
    SESSION_USER,
    SET,
    SETS,
    SETTINGS,
    SHARE,
    SHOW,
    SIMILAR,
    SKIP,
    SLOW,
    SMALLINT,
    SNAPSHOT,
    SOME,
    SORT,
    SOURCE,
    SPATIAL,
    SPECIFIC,
    SPECIFICTYPE,
    SQL,
    SQLEXCEPTION,
    SQLSTATE,
    SQLWARNING,
    SQRT,
    STABLE,
    STAGE,
    START,
    STATEMENT,
    STATIC,
    STATISTICS,
    STATUS,
    STDDEV_POP,
    STDDEV_SAMP,
    STDIN,
    STDOUT,
    STEP,
    STORAGE_INTEGRATION,
    STORED,
    STRICT,
    STRING,
    STRUCT,
    SUBMULTISET,
    SUBSTRING,
    SUBSTRING_REGEX,
    SUCCEEDS,
    SUM,
    SUPER,
    SUPERUSER,
    SWAP,
    SYMMETRIC,
    SYNC,
    SYSTEM,
    SYSTEM_TIME,
    SYSTEM_USER,
    TABLE,
    TABLES,
    TABLESAMPLE,
    TAG,
    TARGET,
    TBLPROPERTIES,
    TEMP,
    TEMPORARY,
    TERMINATED,
    TEXT,
    TEXTFILE,
    THEN,
    TIES,
    TIME,
    TIMESTAMP,
    TIMESTAMPTZ,
    TIMETZ,
    TIMEZONE,
    TIMEZONE_ABBR,
    TIMEZONE_HOUR,
    TIMEZONE_MINUTE,
    TIMEZONE_REGION,
    TINYINT,
    TO,
    TOP,
    TOTALS,
    TRAILING,
    TRANSACTION,
    TRANSIENT,
    TRANSLATE,
    TRANSLATE_REGEX,
    TRANSLATION,
    TREAT,
    TRIGGER,
    TRIM,
    TRIM_ARRAY,
    TRUE,
    TRUNCATE,
    TRY_CAST,
    TUPLE,
    TYPE,
    UESCAPE,
    UINT128,
    UINT16,
    UINT256,
    UINT32,
    UINT64,
    UINT8,
    UNBOUNDED,
    UNCACHE,
    UNCOMMITTED,
    UNION,
    UNIQUE,
    UNKNOWN,
    UNLOAD,
    UNLOCK,
    UNLOGGED,
    UNMATCHED,
    UNNEST,
    UNPIVOT,
    UNSAFE,
    UNSIGNED,
    UNTIL,
    UPDATE,
    UPPER,
    URL,
    USAGE,
    USE,
    USER,
    USER_RESOURCES,
    USING,
    UUID,
    VALID,
    VALIDATION_MODE,
    VALUE,
    VALUE_OF,
    VALUES,
    VAR_POP,
    VAR_SAMP,
    VARBINARY,
    VARCHAR,
    VARIABLES,
    VARYING,
    VERBOSE,
    VERSION,
    VERSIONING,
    VIEW,
    VIRTUAL,
    VOLATILE,
    WEEK,
    WHEN,
    WHENEVER,
    WHERE,
    WIDTH_BUCKET,
    WINDOW,
    WITH,
    WITHIN,
    WITHOUT,
    WITHOUT_ARRAY_WRAPPER,
    WORK,
    WRITE,
    XML,
    XOR,
    YEAR,
    ZONE,

    undefined
}