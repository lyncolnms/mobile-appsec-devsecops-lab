# Lab MDM/MAM/MTD (Intune + Defender)

Objetivo: aplicar políticas MAM/MDM e avaliar risco do dispositivo com MTD.

Pré-requisitos
- Tenant Microsoft 365 Developer (E5) e licença de teste para Intune + Defender for Endpoint (MDE).

Passos
1) Habilite a inscrição de dispositivos e crie grupos de teste (usuários e dispositivos).
2) Crie App Protection Policies (MAM) para iOS/Android com:
   - PIN biométrico, restrição de copy/paste, dados corporativos criptografados.
3) Configure Conditional Access baseado em risco:
   - Bloqueie acesso a apps corporativos se o risco do dispositivo >= Medium (sinal do MDE).
4) Integre MDE com Intune:
   - Ative a conexão e valide a avaliação de risco em tempo real.
5) Implante um app MAUI gerenciado:
   - Use Managed App Config para chaves não sensíveis e flags de telemetria.

Entregáveis
- Export das políticas (JSON), diagrama do fluxo e vídeo curto demonstrando bloqueio por risco.
