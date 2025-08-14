# API Security Demo

Objetivo: praticar OWASP API Top 10 com uma API simples descrita em `openapi.yaml`.

Passos
1) Use o Postman para importar `tests/postman_collection.json` e rodar requests.
2) Gere tráfego via Burp/ZAP e tente casos do API Top 10 (auth, BOLA, rate limit).
3) Fuzzing: `schemathesis run --checks all --targets all openapi.yaml --base-url http://localhost:8080`

Sugestão de implementação de backend
- .NET Minimal APIs / Node / Python — você decide. Mantenha a spec atualizada.
- Adicione falhas intencionais (ex.: endpoint de lista sem checar ownerId) para praticar BOLA.

Observação
- Há apenas a spec e uma collection mínima — a implementação fica ao seu critério para praticar.
