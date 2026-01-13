namespace RedCardinal.Compliance.Abstractions.Iso27001;

/// <summary>
/// ISO/IEC 27001:2022 Annex A control themes.
/// </summary>
public enum Iso27001Theme
{
    /// <summary>
    /// A.5 - Organizational controls (37 controls).
    /// Policies, roles, responsibilities, and management of information security.
    /// </summary>
    Organizational,

    /// <summary>
    /// A.6 - People controls (8 controls).
    /// Human resource security, awareness, and training.
    /// </summary>
    People,

    /// <summary>
    /// A.7 - Physical controls (14 controls).
    /// Physical security perimeters, equipment, and media handling.
    /// </summary>
    Physical,

    /// <summary>
    /// A.8 - Technological controls (34 controls).
    /// Technical security measures including access control, cryptography, and operations security.
    /// </summary>
    Technological
}