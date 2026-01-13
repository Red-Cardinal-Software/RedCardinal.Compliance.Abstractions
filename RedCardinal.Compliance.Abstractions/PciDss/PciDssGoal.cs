namespace RedCardinal.Compliance.Abstractions.PciDss;

/// <summary>
/// PCI DSS v4.0 high-level goals.
/// </summary>
public enum PciDssGoal
{
    /// <summary>
    /// Build and Maintain a Secure Network and Systems.
    /// Requirements 1-2.
    /// </summary>
    SecureNetwork,

    /// <summary>
    /// Protect Account Data.
    /// Requirements 3-4.
    /// </summary>
    ProtectAccountData,

    /// <summary>
    /// Maintain a Vulnerability Management Program.
    /// Requirements 5-6.
    /// </summary>
    VulnerabilityManagement,

    /// <summary>
    /// Implement Strong Access Control Measures.
    /// Requirements 7-9.
    /// </summary>
    AccessControl,

    /// <summary>
    /// Regularly Monitor and Test Networks.
    /// Requirements 10-11.
    /// </summary>
    MonitorAndTest,

    /// <summary>
    /// Maintain an Information Security Policy.
    /// Requirement 12.
    /// </summary>
    SecurityPolicy
}