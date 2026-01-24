namespace RedCardinal.Compliance.Abstractions.Soc2;

/// <summary>
/// Marks code as implementing or supporting a SOC 2 Trust Service Criteria control.
/// </summary>
/// <remarks>
/// SOC 2 controls are organized into five Trust Service Categories:
/// <list type="bullet">
/// <item><description>CC (Common Criteria/Security) - CC1.x through CC9.x</description></item>
/// <item><description>A (Availability) - A1.x</description></item>
/// <item><description>PI (Processing Integrity) - PI1.x</description></item>
/// <item><description>C (Confidentiality) - C1.x</description></item>
/// <item><description>P (Privacy) - P1.x through P8.x</description></item>
/// </list>
/// </remarks>
/// <example>
/// <code>
/// [Soc2Control("CC6.1", Description = "Implements logical access security")]
/// public class AuthenticationService { }
///
/// [Soc2Control("CC6.2", Category = Soc2Category.Security)]
/// public void ValidateUserCredentials() { }
/// </code>
/// </example>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface |
    AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Event | AttributeTargets.Constructor | AttributeTargets.Assembly,
    AllowMultiple = true,
    Inherited = true)]
public sealed class Soc2ControlAttribute : ComplianceAttributeBase
{
    /// <inheritdoc />
    public override ComplianceFramework Framework => ComplianceFramework.Soc2;

    /// <summary>
    /// Gets or sets the Trust Service Category this control belongs to.
    /// </summary>
    public Soc2Category? Category { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Soc2ControlAttribute"/> class.
    /// </summary>
    /// <param name="controlId">
    /// The SOC 2 control identifier (e.g., "CC6.1", "A1.2", "PI1.1", "C1.1", "P1.1").
    /// </param>
    public Soc2ControlAttribute(string controlId) : base(controlId)
    {
    }
}