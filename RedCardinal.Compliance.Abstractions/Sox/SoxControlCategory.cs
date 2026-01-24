namespace RedCardinal.Compliance.Abstractions.Sox;

/// <summary>
/// SOX IT General Control (ITGC) categories.
/// </summary>
public enum SoxControlCategory
{
    /// <summary>
    /// Access to Programs and Data.
    /// Controls ensuring only authorized users can access systems and data.
    /// </summary>
    AccessControl,

    /// <summary>
    /// Program Changes / Change Management.
    /// Controls over modifications to applications and systems.
    /// </summary>
    ChangeManagement,

    /// <summary>
    /// Program Development.
    /// Controls over new system development and implementation.
    /// </summary>
    ProgramDevelopment,

    /// <summary>
    /// Computer Operations.
    /// Controls over data center operations, job scheduling, and backups.
    /// </summary>
    ComputerOperations,

    /// <summary>
    /// Data Backup and Recovery.
    /// Controls ensuring data can be recovered.
    /// </summary>
    BackupAndRecovery,

    /// <summary>
    /// Segregation of Duties.
    /// Controls preventing conflicts of interest.
    /// </summary>
    SegregationOfDuties,

    /// <summary>
    /// System Security.
    /// General security controls.
    /// </summary>
    SystemSecurity,

    /// <summary>
    /// Logging and Monitoring.
    /// Audit trail and monitoring controls.
    /// </summary>
    LoggingAndMonitoring
}