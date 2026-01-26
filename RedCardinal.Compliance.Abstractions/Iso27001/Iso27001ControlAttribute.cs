namespace RedCardinal.Compliance.Abstractions.Iso27001;

/// <summary>
/// Marks code as implementing or supporting an ISO/IEC 27001 Annex A control.
/// </summary>
/// <remarks>
/// ISO 27001:2022 controls are organized into four themes:
/// <list type="bullet">
/// <item><description>A.5 - Organizational controls</description></item>
/// <item><description>A.6 - People controls</description></item>
/// <item><description>A.7 - Physical controls</description></item>
/// <item><description>A.8 - Technological controls</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [Iso27001Control("A.8.3", Description = "Information access restriction")]
/// public class AccessControlService { }
///
/// [Iso27001Control("A.8.24", Theme = Iso27001Theme.Technological)]
/// public void EncryptData() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class Iso27001ControlAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Iso27001;

    /// <summary>
    /// Gets or sets the control theme/category.
    /// </summary>
    public Iso27001Theme? Theme { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Iso27001ControlAttribute"/> class.
    /// </summary>
    /// <param name="controlId">
    /// The ISO 27001 control identifier (e.g., "A.5.1", "A.8.24").
    /// </param>
    public Iso27001ControlAttribute(string controlId) : base(controlId)
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Iso27001ControlAttribute"/> class with a specific theme.
    /// </summary>
    /// <param name="controlId">The ISO 27001 control identifier.</param>
    /// <param name="theme">The control theme/category.</param>
    public Iso27001ControlAttribute(string controlId, Iso27001Theme theme) : base(controlId)
    {
        Theme = theme;
    }
}