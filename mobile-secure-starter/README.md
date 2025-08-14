# Mobile Secure Starter (.NET MAUI)

Este pacote contém blocos de construção para segurança em MAUI:
- SecureStorageService: wrapper centralizado para armazenamento seguro
- PinningHttpClientHandler: pinning por SPKI (SHA-256) com validação de host
- AntiTamperService: deteção de debugger e ambiente comprometido
- Root/Jailbreak detection (Android/iOS) – com técnicas básicas
- Diretrizes MASVS/MSTG aplicadas a MAUI

Integração
- Copie os arquivos de src/ para seu projeto MAUI.
- Registre serviços via DI no MauiProgram.cs.
- Use PinningHttpClientHandler ao criar HttpClient para APIs sensíveis.

Dicas
- Gere o hash SPKI do seu endpoint com `openssl` e carregue no handler.
- Evite armazenar tokens de longa duração; prefira refresh tokens de curta duração e rotate.

Atenção
- Técnicas de root/jailbreak detection são heurísticas e podem ter bypass.
- Pinning mal configurado pode quebrar tráfego legítimo; implemente fallback e telemetria.
