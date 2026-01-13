namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Represents the result of a compliance probe verification.
/// </summary>
public class ComplianceProbeResult
{
    /// <summary>
    /// Gets a value indicating whether the probe verification passed.
    /// </summary>
    public bool IsCompliant { get; }

    /// <summary>
    /// Gets a message describing the verification result.
    /// </summary>
    public string? Message { get; }

    /// <summary>
    /// Gets the timestamp when the verification was performed.
    /// </summary>
    public DateTimeOffset Timestamp { get; }

    /// <summary>
    /// Gets additional evidence data collected during verification.
    /// Keys and values are implementation-specific.
    /// </summary>
    public IReadOnlyDictionary<string, object>? Evidence { get; }

    /// <summary>
    /// Gets the severity level if the probe found issues.
    /// </summary>
    public ProbeSeverity? Severity { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplianceProbeResult"/> class.
    /// </summary>
    /// <param name="isCompliant">Whether the verification passed.</param>
    /// <param name="message">An optional message describing the result.</param>
    /// <param name="evidence">Optional evidence data collected during verification.</param>
    /// <param name="severity">Optional severity level for non-compliant results.</param>
    public ComplianceProbeResult(
        bool isCompliant,
        string? message = null,
        IReadOnlyDictionary<string, object>? evidence = null,
        ProbeSeverity? severity = null)
    {
        IsCompliant = isCompliant;
        Message = message;
        Timestamp = DateTimeOffset.UtcNow;
        Evidence = evidence;
        Severity = severity;
    }

    /// <summary>
    /// Creates a successful (compliant) probe result.
    /// </summary>
    /// <param name="message">An optional success message.</param>
    /// <param name="evidence">Optional evidence data.</param>
    /// <returns>A compliant <see cref="ComplianceProbeResult"/>.</returns>
    public static ComplianceProbeResult Success(string? message = null, IReadOnlyDictionary<string, object>? evidence = null)
        => new(true, message, evidence);

    /// <summary>
    /// Creates a failed (non-compliant) probe result.
    /// </summary>
    /// <param name="message">A message describing the failure.</param>
    /// <param name="severity">The severity of the failure.</param>
    /// <param name="evidence">Optional evidence data.</param>
    /// <returns>A non-compliant <see cref="ComplianceProbeResult"/>.</returns>
    public static ComplianceProbeResult Failure(string message, ProbeSeverity severity = ProbeSeverity.High, IReadOnlyDictionary<string, object>? evidence = null)
        => new(false, message, evidence, severity);
}

/// <summary>
/// Indicates the severity of a compliance probe failure.
/// </summary>
public enum ProbeSeverity
{
    /// <summary>
    /// Informational finding that may not require immediate action.
    /// </summary>
    Info,

    /// <summary>
    /// Low severity finding.
    /// </summary>
    Low,

    /// <summary>
    /// Medium severity finding that should be addressed.
    /// </summary>
    Medium,

    /// <summary>
    /// High severity finding requiring prompt attention.
    /// </summary>
    High,

    /// <summary>
    /// Critical finding requiring immediate remediation.
    /// </summary>
    Critical
}