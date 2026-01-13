namespace RedCardinal.Compliance.Abstractions.Cmmc;

/// <summary>
/// CMMC 2.0 certification levels.
/// </summary>
public enum CmmcLevel
{
    /// <summary>
    /// Level 1 - Foundational.
    /// 15 practices from FAR 52.204-21 for FCI protection.
    /// Annual self-assessment.
    /// </summary>
    Level1,

    /// <summary>
    /// Level 2 - Advanced.
    /// 110 practices aligned with NIST SP 800-171 for CUI protection.
    /// Triennial third-party assessment or annual self-assessment.
    /// </summary>
    Level2,

    /// <summary>
    /// Level 3 - Expert.
    /// 134 practices (110 from NIST SP 800-171 + 24 from NIST SP 800-172) for critical CUI protection.
    /// Triennial government-led (DIBCAC) assessment.
    /// </summary>
    Level3
}