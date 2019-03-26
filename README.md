# GameList
<h2>Уеб базиран каталог за игри</h2>
<h3>1.Структура на системата по модели:</h3>
<h4>Game</h4>
Int GameId<br>
String Name*<br>
String ReleaseYear*<br>
Int GenreId<br>
Int RatingId<br>
<h4>Genre</h4>
Int GenreId<br>
String GenreName*<br>
String Description
<h4>Rating</h4>
Int RatingId<br>
String RatingValue*<br>
String Description
<h3>2.Ограничения:</h3>
Задължителни полета са всички полета след, които има *.<br>
Допустими символи:<br>
Game.Name –допустими символи между1 и 200.<br>
Genre.GenreName –допустими символи между 1 и 100.<br>
Rating.RatingValue –допустими символи между1 и 100.<br>
Rating.Description–допустими символи между1 и 400.
<h3>3.Към всеки модел трябва да бъде изграден CRUD от изгледи.</h3>
<h3>4.Филтри:</h3>
Към изглед Games/Index трябва да се изгради странициране и сортиране по колони: Name, Genre и Rating.<br>
<h3>5.Да се изгради и система за идентифициране със следните роли в нея:</h3>
Admin – имапълен достъп.<br>
User – Имат достъп до Games/Indexсамо,и може да използватърсачката на страницата.Няма достъп до страниците за Create, Update, Delete, но може да преглежда продукта Details.<br>
Anonymous –нерегистриран потребител. Има възможност да виждасамо изглед Games/Index.Като бутоните за редактиране, изтриване и добавяне на нов са забранени.
<h3>Легенда:</h3>
В заданието за описание на контролер към изглед ще използвам следното съкращение:<br>
Пример: Изглед Index към контролер Games–> Games/Index
