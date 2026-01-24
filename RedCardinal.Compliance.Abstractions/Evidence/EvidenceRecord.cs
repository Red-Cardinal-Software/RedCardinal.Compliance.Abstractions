namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Represents a collected evidence record suitable for compliance reporting,
/// including fields compatible with OSCAL (Open Security Controls Assessment Language).
/// </summary>
public class EvidenceRecord
{
    /// <summary>
    /// Gets the identifier of the provider that generated this evidence.
    /// </summary>
    public string ProviderId { get; }

    /// <summary>
    /// Gets a description of the evidence.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the timestamp when this evidence was collected.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Gets an optional cryptographic hash providing integrity verification.
    /// </summary>
    public string? Hash { get; }

    /// <summary>
    /// Gets the hash algorithm used (e.g., "SHA-256", "SHA-384").
    /// </summary>
    public string? HashAlgorithm { get; }

    #region OSCAL-Compatible Fields

    /// <summary>
    /// Gets or sets the OSCAL subject UUID this evidence relates to.
    /// Maps to OSCAL assessment-results subject-uuid.
    /// </summary>
    public Guid? SubjectUuid { get; set; }

    /// <summary>
    /// Gets or sets the OSCAL component UUID this evidence relates to.
    /// Maps to OSCAL component-definition component uuid.
    /// </summary>
    public Guid? ComponentUuid { get; set; }

    /// <summary>
    /// Gets or sets the OSCAL observation UUID for this evidence.
    /// Maps to OSCAL assessment-results observation uuid.
    /// </summary>
    public Guid? ObservationUuid { get; set; }

    /// <summary>
    /// Gets or sets the observation method (e.g., "TEST", "EXAMINE", "INTERVIEW").
    /// Maps to OSCAL observation method.
    /// </summary>
    public string? ObservationMethod { get; set; }

    /// <summary>
    /// Gets or sets the evidence type for OSCAL categorization.
    /// </summary>
    public string? OscalEvidenceType { get; set; }

    #endregion

    /// <summary>
    /// Gets additional metadata as key-value pairs.
    /// Can include OSCAL properties, links, or implementation-specific data.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; }

    /// <summary>
    /// Gets the raw evidence data, if applicable.
    /// </summary>
    public byte[]? RawData { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EvidenceRecord"/> class.
    /// </summary>
    /// <param name="providerId">The identifier of the provider generating this evidence.</param>
    /// <param name="description">A description of the evidence.</param>
    /// <param name="hash">An optional cryptographic hash.</param>
    /// <param name="hashAlgorithm">The hash algorithm used.</param>
    /// <param name="timestamp">The collection timestamp. Defaults to current UTC time.</param>
    /// <param name="metadata">Optional additional metadata.</param>
    public EvidenceRecord(
        string providerId,
        string description,
        string? hash = null,
        string? hashAlgorithm = null,
        DateTimeOffset? timestamp = null,
        IReadOnlyDictionary<string, string>? metadata = null)
    {
        ProviderId = providerId ?? throw new ArgumentNullException(nameof(providerId));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Hash = hash;
        HashAlgorithm = hashAlgorithm ?? (hash != null ? "SHA-256" : null);
        Timestamp = timestamp ?? DateTimeOffset.UtcNow;
        Metadata = metadata;
    }
}