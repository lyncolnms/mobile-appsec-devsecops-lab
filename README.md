# Mobile Security Template (MAUI + AppSec + DevSecOps + API + MDM/MTD + Pentest Mobile)

Este monorepo serve como base prática para:
- Mobile AppSec (MASVS/MSTG) em apps .NET MAUI
- DevSecOps (CodeQL, Semgrep, SBOM) com GitHub Actions
- API Security para backends consumidos por mobile (OWASP API Top 10)
- MDM/MAM/MTD (Intune + Defender) — guias e artefatos
- Pentest Mobile — labs, cheatsheets e relatório MSTG

Estrutura:
- mobile-secure-starter/: serviços e exemplos de segurança para MAUI
- api-sec-demo/: OpenAPI + testes (Postman/Schemathesis) para API de app
- mdm-mam-mtd-lab/: guia prático de políticas e integrações
- pentest-mobile/: material de teste, frida cheatsheet, templates de relatório
- docs/masvs-checklist-maui.md: checklist MASVS v2 preenchível para MAUI
- .github/workflows/: pipelines de CodeQL, Semgrep e SBOM

Como usar
1) Fork/clone e abra no VS Code.
2) Ative GitHub Advanced Security (se disponível) e configure Secrets se necessário.
3) No seu app MAUI, consuma os serviços em mobile-secure-starter/src/Security.
4) Use api-sec-demo para praticar OWASP API Top 10; execute testes Postman/Schemathesis.
5) Siga mdm-mam-mtd-lab/README.md para montar um tenant de lab com Intune + Defender.
6) Use o checklist MASVS em docs para avaliar seu app e registrar evidências.

Avisos
- Realize testes apenas em apps/ambientes sob sua autorização.
- Sanitize dados antes de publicar relatórios/write-ups.

Licença - MIT (ajuste conforme sua necessidade)
