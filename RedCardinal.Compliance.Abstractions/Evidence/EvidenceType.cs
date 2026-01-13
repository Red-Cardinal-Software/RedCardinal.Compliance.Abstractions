namespace RedCardinal.Compliance.Abstractions.Evidence;

/// <summary>
/// Types of compliance evidence that can be documented in code.
/// </summary>
public enum EvidenceType
{
    /// <summary>
    /// Technical implementation of a control.
    /// </summary>
    Implementation,

    /// <summary>
    /// Configuration or setting that enforces a control.
    /// </summary>
    Configuration,

    /// <summary>
    /// Validation or verification logic.
    /// </summary>
    Validation,

    /// <summary>
    /// Logging or audit trail implementation.
    /// </summary>
    AuditLog,

    /// <summary>
    /// Monitoring or alerting implementation.
    /// </summary>
    Monitoring,

    /// <summary>
    /// Encryption or cryptographic control.
    /// </summary>
    Encryption,

    /// <summary>
    /// Access control or authorization logic.
    /// </summary>
    AccessControl,

    /// <summary>
    /// Authentication mechanism.
    /// </summary>
    Authentication,

    /// <summary>
    /// Data protection or privacy control.
    /// </summary>
    DataProtection,

    /// <summary>
    /// Error handling or exception management.
    /// </summary>
    ErrorHandling,

    /// <summary>
    /// Input validation or sanitization.
    /// </summary>
    InputValidation,

    /// <summary>
    /// Business logic control.
    /// </summary>
    BusinessLogic,

    /// <summary>
    /// Testing or quality assurance evidence.
    /// </summary>
    Testing,

    /// <summary>
    /// Documentation of a process or procedure.
    /// </summary>
    Procedure
}