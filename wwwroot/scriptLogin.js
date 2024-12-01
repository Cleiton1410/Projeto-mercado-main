async function verificacao(event) {
    event.preventDefault();

    const res = {
        nome: document.getElementById("name").value,
        senha: document.getElementById("senha").value
    };

    try {
        const login = await fetch("/app/login", {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });

        if (!login.ok) {
            throw new Error(await login.text());
        }

        // Corrigido para pegar o JSON da resposta
        const result = await login.json();
        console.log(result);
    } catch (error) {
        console.error("Mensagem erro: " + error);
    }
}

document.getElementById("logar").addEventListener("submit", verificacao);
