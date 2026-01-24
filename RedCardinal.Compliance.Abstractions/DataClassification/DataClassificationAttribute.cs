namespace RedCardinal.Compliance.Abstractions.DataClassification;

/// <summary>
/// Marks a code element as handling data of a specific classification level.
/// Used to identify where sensitive data is processed, stored, or transmitted.
/// </summary>
/// <example>
/// <code>
/// [DataClassification(DataSensitivity.Pii, "Stores user email addresses")]
/// public string Email { get; set; }
///
/// [DataClassification(DataSensitivity.Phi)]
/// public class PatientRecordService { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Parameter | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = true)]
public sealed class DataClassificationAttribute : Attribute
{
    /// <summary>
    /// Gets the sensitivity level of the data.
    /// </summary>
    public DataSensitivity Sensitivity { get; }

    /// <summary>
    /// Gets the description of what sensitive data is handled.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the specific data types handled (e.g., "SSN", "Credit Card", "Email").
    /// </summary>
    public string[]? DataTypes { get; set; }

    /// <summary>
    /// Gets or sets whether this data requires encryption at rest.
    /// </summary>
    public bool RequiresEncryptionAtRest { get; set; }

    /// <summary>
    /// Gets or sets whether this data requires encryption in transit.
    /// </summary>
    public bool RequiresEncryptionInTransit { get; set; }

    /// <summary>
    /// Gets or sets the data retention period in days. Use -1 for indefinite.
    /// </summary>
    public int RetentionDays { get; set; } = -1;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataClassificationAttribute"/> class.
    /// </summary>
    /// <param name="sensitivity">The sensitivity level of the data.</param>
    public DataClassificationAttribute(DataSensitivity sensitivity)
    {
        Sensitivity = sensitivity;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataClassificationAttribute"/> class.
    /// </summary>
    /// <param name="sensitivity">The sensitivity level of the data.</param>
    /// <param name="description">Description of what sensitive data is handled.</param>
    public DataClassificationAttribute(DataSensitivity sensitivity, string description)
    {
        Sensitivity = sensitivity;
        Description = description;
    }
}