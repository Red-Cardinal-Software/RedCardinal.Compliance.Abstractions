namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Defines a compliance probe that can verify a specific control or requirement at runtime.
/// Implementations allow compliance engines to discover and execute verification tests
/// without knowing the specific implementation details.
/// </summary>
/// <remarks>
/// Use this interface to create probes that verify runtime compliance state,
/// such as checking database ledger integrity, key rotation status, or access control configurations.
/// </remarks>
/// <example>
/// <code>
/// public class SqlLedgerProbe : IComplianceProbe
/// {
///     public string ProbeId => "sql-ledger-integrity";
///     public string Name => "SQL Ledger Integrity Check";
///     public string? Description => "Verifies SQL Server ledger tables have not been tampered with";
///     public IReadOnlyCollection&lt;string&gt; RelatedControlIds => new[] { "CC6.1", "PI1.1" };
///
///     public async Task&lt;ComplianceProbeResult&gt; VerifyAsync(CancellationToken cancellationToken = default)
///     {
///         // Implementation verifies ledger integrity
///     }
/// }
/// </code>
/// </example>
public interface IComplianceProbe
{
    /// <summary>
    /// Gets a unique identifier for this probe.
    /// </summary>
    string ProbeId { get; }

    /// <summary>
    /// Gets a human-readable name for this probe.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets a description of what this probe verifies.
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// Gets the collection of control identifiers this probe helps verify.
    /// These correspond to ControlId values from compliance attributes (e.g., "CC6.1", "A.8.24").
    /// </summary>
    IReadOnlyCollection<string> RelatedControlIds { get; }

    /// <summary>
    /// Executes the compliance verification and returns the result.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A <see cref="ComplianceProbeResult"/> containing the verification outcome.</returns>
    Task<ComplianceProbeResult> VerifyAsync(CancellationToken cancellationToken = default);
}