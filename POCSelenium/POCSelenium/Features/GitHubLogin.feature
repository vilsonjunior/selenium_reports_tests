@GitHub.Login
Funcionalidade: GitHub

Cenário: Validar login no github com usuário e senha inválidos
	Dado que acesse a url 'https://github.com/login'
	Quando preencher o campo 'login_field' com 'usuario_teste'
	E preencher o campo 'password' com 'senha'
	E clicar no botão 'commit'
	Então deve exibir a mensagem 'Incorrect username or password.'

