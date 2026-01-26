# RedCardinal.Compliance.Abstractions

A .NET library providing compliance framework attributes for annotating code with control mappings. Enables static analysis and audit reporting for compliance frameworks.

## Installation

```bash
dotnet add package RedCardinal.Compliance.Abstractions
```

## Supported Frameworks

| Framework | Description |
|-----------|-------------|
| **SOC 2** | Trust Service Criteria (CC, A, PI, C, P categories) |
| **ISO 27001** | Information Security Management System controls |
| **GDPR** | General Data Protection Regulation (EU) |
| **PCI-DSS** | Payment Card Industry Data Security Standard |
| **HIPAA** | Health Insurance Portability and Accountability Act |
| **CCPA** | California Consumer Privacy Act |
| **CMMC** | Cybersecurity Maturity Model Certification (DoD) |
| **SOX** | Sarbanes-Oxley Act IT controls |
| **NIST CSF** | NIST Cybersecurity Framework |

## Quick Start

### Mapping Controls to Code

```csharp
using RedCardinal.Compliance.Abstractions.Soc2;
using RedCardinal.Compliance.Abstractions.Iso27001;
using RedCardinal.Compliance.Abstractions.Hipaa;

[Soc2Control("CC6.1", Description = "Implements logical access controls")]
[Iso27001Control("A.8.3", Description = "Information access restriction")]
[HipaaControl("164.312(a)(1)", HipaaSafeguard.Technical)]
public class AuthenticationService
{
    [Soc2Control("CC6.2")]
    public bool ValidateCredentials(string username, string password)
    {
        // Implementation
    }
}
```

### Data Classification

```csharp
using RedCardinal.Compliance.Abstractions.DataClassification;

public class UserProfile
{
    [DataClassification(DataSensitivity.Pii)]
    [PersonalData(PersonalDataCategory.Contact)]
    public string Email { get; set; }

    [DataClassification(DataSensitivity.Phi, RequiresEncryptionAtRest = true)]
    public string MedicalRecordNumber { get; set; }

    [DataClassification(DataSensitivity.Pci)]
    public string CreditCardNumber { get; set; }
}
```

### Documenting Evidence

```csharp
using RedCardinal.Compliance.Abstractions.Evidence;

[ComplianceEvidence(
    EvidenceType.Encryption,
    "Uses AES-256-GCM encryption exceeding minimum requirements",
    RelatedControls = new[] { "CC6.1", "A.8.24", "PCI-DSS 3.5.1" })]
public class EncryptionService
{
    [AuditNote("Key rotation occurs every 90 days per security policy")]
    public void EncryptData(byte[] data) { }
}
```

### Justifications and Exceptions

```csharp
using RedCardinal.Compliance.Abstractions.Evidence;

[ComplianceJustification(
    "PCI-DSS 3.5.1",
    "Using AES-256 which exceeds the minimum AES-128 requirement",
    JustificationType.ExceedsRequirement,
    ApprovedBy = "Security Team")]
public class CardEncryption { }

[ComplianceJustification(
    "HIPAA",
    "Service only processes anonymized data - no PHI present",
    JustificationType.NotApplicable)]
public class AnonymousAnalyticsService { }
```

## Framework-Specific Attributes

### SOC 2

```csharp
[Soc2Control("CC6.1", Soc2Category.Security)]
[Soc2Control("A1.2", Soc2Category.Availability)]
```

Categories: `Security`, `Availability`, `ProcessingIntegrity`, `Confidentiality`, `Privacy`

### ISO 27001

```csharp
[Iso27001Control("A.8.24", Iso27001Theme.Technological)]
```

Themes: `Organizational`, `People`, `Physical`, `Technological`

### GDPR

```csharp
[GdprArticle("17", GdprPrinciple.StorageLimitation, Paragraph = "1")]
```

Principles: `LawfulnessFairnessTransparency`, `PurposeLimitation`, `DataMinimisation`, `Accuracy`, `StorageLimitation`, `SecurityOfProcessing`, `Accountability`

### PCI-DSS

```csharp
[PciDssRequirement("3.5.1", PciDssGoal.ProtectAccountData)]
```

Goals: `SecureNetwork`, `ProtectAccountData`, `VulnerabilityManagement`, `AccessControl`, `IdentifyAndAuthenticate`, `MonitorAndTest`, `SecurityPolicy`

### HIPAA

```csharp
[HipaaControl("164.312(a)(1)", HipaaSafeguard.Technical)]
[HipaaControl("164.312(e)(1)", HipaaRequirementType.Addressable)]
```

Safeguards: `Administrative`, `Physical`, `Technical`, `Organizational`, `PoliciesAndProcedures`

### CCPA

```csharp
[CcpaRequirement("1798.105", CcpaRight.RightToDelete)]
[CcpaRequirement("1798.120", CcpaRight.RightToOptOut)]
```

Rights: `RightToKnow`, `RightToDelete`, `RightToOptOut`, `RightToNonDiscrimination`, `RightToCorrect`, `RightToLimitUse`, `RightToAccess`, `RightToPortability`

### CMMC

```csharp
[CmmcPractice("AC.L2-3.1.1", CmmcDomain.AccessControl, CmmcLevel.Level2)]
```

Levels: `Level1`, `Level2`, `Level3`

Domains: `AccessControl`, `AwarenessAndTraining`, `AuditAndAccountability`, `ConfigurationManagement`, `IdentificationAndAuthentication`, `IncidentResponse`, `Maintenance`, `MediaProtection`, `PersonnelSecurity`, `PhysicalProtection`, `RiskAssessment`, `SecurityAssessment`, `SystemAndCommunicationsProtection`, `SystemAndInformationIntegrity`

### SOX

```csharp
[SoxControl("ITGC-AC-01", SoxControlCategory.AccessControl, Section = "404")]
```

Categories: `AccessControl`, `ChangeManagement`, `ProgramDevelopment`, `ComputerOperations`, `BackupAndRecovery`, `SegregationOfDuties`, `SystemSecurity`, `LoggingAndMonitoring`

Control Types: `Itgc`, `ApplicationControl`, `ItDependentManual`, `EntityLevel`

### NIST CSF

```csharp
[NistCsfControl("PR.AC-1", NistCsfFunction.Protect, Tier = 3)]
```

Functions: `Govern`, `Identify`, `Protect`, `Detect`, `Respond`, `Recover`

## Common Properties

All compliance attributes support:

- `Description` - How this code satisfies the control
- `Status` - Implementation status (`NotImplemented`, `InProgress`, `PartiallyImplemented`, `Implemented`, `NotApplicable`)
- `Owner` - Person or team responsible
- `LastReviewedDate` - ISO 8601 date of last review

## Data Sensitivity Levels

`Public`, `Internal`, `Confidential`, `Pii`, `SensitivePii`, `Phi`, `Pci`, `Financial`, `Credentials`, `Restricted`

## Runtime Verification

Beyond static attributes, the library provides interfaces for runtime compliance verification and evidence collection.

### Compliance Probes

Implement `IComplianceProbe` to create runtime verification checks that can be discovered and executed by a compliance engine:

```csharp
using RedCardinal.Compliance.Abstractions.Evidence;

public class SqlLedgerIntegrityProbe : IComplianceProbe
{
    public string ProbeId => "sql-ledger-integrity";
    public string Name => "SQL Ledger Integrity Check";
    public string? Description => "Verifies SQL Server ledger tables have not been tampered with";
    public IReadOnlyCollection<string> RelatedControlIds => new[] { "CC6.1", "PI1.1" };

    public async Task<ComplianceProbeResult> VerifyAsync(CancellationToken cancellationToken = default)
    {
        var isValid = await VerifyLedgerAsync(cancellationToken);

        if (isValid)
        {
            return ComplianceProbeResult.Success(
                "Ledger integrity verified",
                new Dictionary<string, object> { { "verified_at", DateTimeOffset.UtcNow } });
        }

        return ComplianceProbeResult.Failure(
            "Ledger tampering detected",
            ProbeSeverity.Critical);
    }
}
```

Probe results include:
- `IsCompliant` - Whether verification passed
- `Message` - Description of the result
- `Timestamp` - When verification occurred
- `Evidence` - Additional data collected during verification
- `Severity` - For failures: `Info`, `Low`, `Medium`, `High`, `Critical`

### Evidence Providers

Implement `IEvidenceProvider` to collect proof-of-compliance data suitable for OSCAL reports:

```csharp
using RedCardinal.Compliance.Abstractions.Evidence;

public class KeyRotationEvidenceProvider : IEvidenceProvider
{
    public string ProviderId => "key-rotation";
    public string Name => "Encryption Key Rotation Evidence";
    public string? Description => "Provides evidence of encryption key rotation compliance";
    public IReadOnlyCollection<string> RelatedControlIds => new[] { "CC6.1", "A.8.24" };

    public async Task<EvidenceRecord> GetEvidenceAsync(CancellationToken cancellationToken = default)
    {
        var lastRotation = await _keyVault.GetLastRotationDateAsync(cancellationToken);
        var hash = ComputeRotationHash(lastRotation);

        return new EvidenceRecord(
            providerId: ProviderId,
            description: "Encryption keys rotated within 90-day policy period",
            hash: hash,
            hashAlgorithm: "SHA-256")
        {
            // OSCAL-compatible fields
            ComponentUuid = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"),
            ObservationMethod = "TEST",
            OscalEvidenceType = "collected"
        };
    }
}
```

`EvidenceRecord` includes OSCAL-compatible fields:
- `SubjectUuid` - OSCAL assessment subject UUID
- `ComponentUuid` - OSCAL component UUID
- `ObservationUuid` - OSCAL observation UUID
- `ObservationMethod` - Method used (`TEST`, `EXAMINE`, `INTERVIEW`)
- `OscalEvidenceType` - Evidence categorization
- `Metadata` - Additional key-value properties

## Use Cases

1. **Audit Preparation** - Generate reports showing which code implements which controls
2. **Gap Analysis** - Identify controls without code implementation
3. **Documentation** - Keep compliance evidence close to implementation
4. **Code Review** - Reviewers can verify control implementations
5. **Static Analysis** - Build tools to scan for compliance coverage
6. **Runtime Verification** - Execute compliance probes to verify controls at runtime
7. **OSCAL Integration** - Generate machine-readable evidence for automated compliance reporting

## Target Frameworks

- .NET 8.0
- .NET Standard 2.0
- .NET Standard 2.1

## License

MIT License - see LICENSE file for details.