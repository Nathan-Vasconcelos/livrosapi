# Livros API
Api Restful de livros em ASP.NET CORE.
<hr>
<br>
<h2>Rotas:</h2>
<h3>/Livro</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo livro</p>
<p>Get: retorna todos os livros</p>
<p>Get com o Id como parâmetro (Livro/Id): retorna o livro referente ao Id passado</p>
<p>Get com o autor como parâmetro na url (Livro?autor=nomeDoAutor): retorna os livros referente ao autor passado</p>
<p>Put passando o Id como parâmetro (Livro/Id): atualiza os dados do livro referente ao Id passado</p>
<p>Delete passando o Id como parâmetro (Livro/Id): Deleta o livro referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{
  "Titulo": "",
  "AutorId": ,
  "CategoriaId": 
}
</p>
<h3>/Autor</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria um novo autor</p>
<p>Get: retorna todos os autores</p>
<p>Get com o Id como parâmetro (Autor/Id): retorna o autor referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Autor/Id): atualiza os dados do autor referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{
  "Nome": ""
}
</p>
<h3>/Categoria</h3>
<h4>Métodos HTTP:</h4>
<p>Post: Cria uma nova categoria</p>
<p>Get: retorna todas as categorias</p>
<p>Get com o Id como parâmetro (Categoria/Id): retorna a categoria referente ao Id passado</p>
<p>Put passando o Id como parâmetro (Categoria/Id): atualiza os dados da categoria referente ao Id passado</p>
<h4>Formato de envio dos dados em Json:</h4>
<p>
{
  "Nome": ""
}
</p>
<br>
<h2>Relacionamentos:</h2>
<h3>Livro e autor (1:n)</h3>
<p>Um livro pode ter um autor, e o autor um, nunhum ou muitos livros.</p>
<h3>Livro e categoria (1:n)</h3>
<p>Um livro pode ter uma categoria, e a categoria um, nunhum ou muitos livros.</p>
