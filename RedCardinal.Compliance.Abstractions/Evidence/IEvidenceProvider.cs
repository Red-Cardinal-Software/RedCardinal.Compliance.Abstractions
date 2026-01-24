namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Defines a provider that generates compliance evidence for audit reporting.
/// Evidence can include cryptographic hashes, rotation timestamps, or other
/// proof-of-compliance data suitable for injection into OSCAL reports.
/// </summary>
/// <remarks>
/// Implementations of this interface provide "proof of life" evidence
/// that can be automatically collected and included in compliance reports.
/// </remarks>
/// <example>
/// <code>
/// public class KeyRotationEvidenceProvider : IEvidenceProvider
/// {
///     public string ProviderId => "key-rotation-evidence";
///     public string Name => "Encryption Key Rotation Evidence";
///
///     public async Task&lt;EvidenceRecord&gt; GetEvidenceAsync(CancellationToken cancellationToken = default)
///     {
///         var lastRotation = await _keyVault.GetLastRotationDateAsync();
///         return new EvidenceRecord(
///             providerId: ProviderId,
///             description: "Encryption keys rotated within policy period",
///             hash: ComputeRotationHash(lastRotation),
///             timestamp: lastRotation);
///     }
/// }
/// </code>
/// </example>
public interface IEvidenceProvider
{
    /// <summary>
    /// Gets a unique identifier for this evidence provider.
    /// </summary>
    string ProviderId { get; }

    /// <summary>
    /// Gets a human-readable name for this evidence provider.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets a description of what evidence this provider generates.
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// Gets the collection of control identifiers this evidence supports.
    /// </summary>
    IReadOnlyCollection<string> RelatedControlIds { get; }

    /// <summary>
    /// Collects and returns compliance evidence.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An <see cref="EvidenceRecord"/> containing the collected evidence.</returns>
    Task<EvidenceRecord> GetEvidenceAsync(CancellationToken cancellationToken = default);
}