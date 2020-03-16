@GitHub.vilsonjunior
Funcionalidade: GitHub user vilsonjunior

Cenário: Validar acesso ao github de usuário
	Dado que acesse a url 'https://github.com'
	E queira acessar o github do usuário 'vilsonjunior'
	Quando exibir a aba 'Overview'
	Então deve exibir o repositório 'SeleniumReportsTests'