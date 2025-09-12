# MASVS v2 Checklist for .NET MAUI Applications

This checklist helps evaluate mobile app security based on OWASP MASVS v2 requirements for .NET MAUI applications.

## MASVS-STORAGE: Storage

### MASVS-STORAGE-1: The app securely stores sensitive data
- [ ] **1.1** Sensitive data is not stored in application logs
- [ ] **1.2** Sensitive data is not stored in application backups  
- [ ] **1.3** Sensitive data is not stored in shared storage areas accessible to other apps
- [ ] **1.4** Secure storage mechanisms are used (SecureStorage API in MAUI)
- [ ] **1.5** Implemented in code: `SecureStorageService` wrapper is used

### MASVS-STORAGE-2: The app prevents leakage of sensitive data
- [ ] **2.1** App does not write sensitive data to system logs
- [ ] **2.2** App does not expose sensitive data through IPC mechanisms
- [ ] **2.3** Sensitive data is removed from memory after use

## MASVS-CRYPTO: Cryptography

### MASVS-CRYPTO-1: The app employs current strong cryptography
- [ ] **1.1** App uses industry standard cryptographic algorithms
- [ ] **1.2** Cryptographic implementations use current best practices
- [ ] **1.3** App does not use deprecated cryptographic algorithms

### MASVS-CRYPTO-2: The app performs key management according to industry best practices
- [ ] **2.1** Cryptographic keys are not hardcoded in the application
- [ ] **2.2** App uses appropriate key derivation functions
- [ ] **2.3** Symmetric keys are not shared between multiple users/devices

## MASVS-AUTH: Authentication and Session Management

### MASVS-AUTH-1: The app uses secure authentication and authorization protocols
- [ ] **1.1** App implements proper authentication mechanisms
- [ ] **1.2** App uses secure protocols for authentication (OAuth 2.0/OIDC)
- [ ] **1.3** Remote endpoints properly validate authentication credentials

### MASVS-AUTH-2: The app performs local authentication securely
- [ ] **2.1** Local authentication (PIN/biometric) is implemented where appropriate
- [ ] **2.2** Biometric authentication uses secure hardware when available
- [ ] **2.3** Local authentication bypass attempts are detected

## MASVS-NETWORK: Network Communication

### MASVS-NETWORK-1: The app secures all network traffic
- [ ] **1.1** All network traffic uses TLS/HTTPS
- [ ] **1.2** TLS certificate validation is properly implemented
- [ ] **1.3** Certificate pinning is implemented for critical connections
- [ ] **1.4** Implemented in code: `PinningHttpClientHandler` is used

### MASVS-NETWORK-2: The app performs identity pinning for all remote endpoints
- [ ] **2.1** Certificate or public key pinning is implemented
- [ ] **2.2** Pinning failures are properly handled
- [ ] **2.3** Backup pins/certificates are configured

## MASVS-PLATFORM: Platform Integration

### MASVS-PLATFORM-1: The app uses platform features securely
- [ ] **1.1** App uses secure platform APIs
- [ ] **1.2** WebView implementations are secure
- [ ] **1.3** App permissions are minimized and justified

### MASVS-PLATFORM-2: The app uses secure inter-process communication
- [ ] **2.1** App validates all inputs from IPC mechanisms
- [ ] **2.2** App does not expose sensitive functionality through IPC
- [ ] **2.3** Intent filters are properly configured (Android)

## MASVS-CODE: Code Quality

### MASVS-CODE-1: The app requires an up-to-date platform version
- [ ] **1.1** App targets recent platform versions
- [ ] **1.2** App is compiled with current tools and SDKs
- [ ] **1.3** Security updates are regularly applied

### MASVS-CODE-2: The app has a mechanism to enforce updates
- [ ] **2.1** App can detect when updates are available
- [ ] **2.2** Critical security updates can be enforced
- [ ] **2.3** Update mechanism itself is secure

## MASVS-RESILIENCE: Anti-Tampering and Anti-Reversing

### MASVS-RESILIENCE-1: The app validates the integrity of the platform
- [ ] **1.1** App detects when running on rooted/jailbroken devices
- [ ] **1.2** Implemented in code: `AntiTamperService.IsCompromisedDevice()` is used
- [ ] **1.3** App responds appropriately to integrity violations

### MASVS-RESILIENCE-2: The app implements anti-tampering mechanisms
- [ ] **2.1** App detects debugger attachment
- [ ] **2.2** Implemented in code: `AntiTamperService.IsDebuggerAttached()` is used
- [ ] **2.3** App implements runtime application self-protection (RASP)

### MASVS-RESILIENCE-3: The app implements anti-static analysis mechanisms
- [ ] **3.1** Code obfuscation is implemented
- [ ] **3.2** Anti-static analysis techniques are used
- [ ] **3.3** String encryption/obfuscation is implemented

### MASVS-RESILIENCE-4: The app implements anti-dynamic analysis mechanisms
- [ ] **4.1** Runtime detection mechanisms are implemented
- [ ] **4.2** Anti-hook/anti-instrumentation techniques are used
- [ ] **4.3** Environment analysis is performed

## Implementation Notes

### Code References
- `SecureStorageService`: Located in `mobile-secure-starter/src/Security/SecureStorageService.cs`
- `PinningHttpClientHandler`: Located in `mobile-secure-starter/src/Security/PinningHttpClientHandler.cs`
- `AntiTamperService`: Located in `mobile-secure-starter/src/Security/AntiTamperService.cs`
- Root/Jailbreak Detection: Located in `mobile-secure-starter/src/Platforms/`

### Testing Evidence
For each checked item, document:
- Code location/implementation
- Test results/screenshots
- Security assessment evidence
- Mitigation strategies for any identified issues

---
*This checklist is based on OWASP MASVS v2.0.0 and adapted for .NET MAUI applications.*