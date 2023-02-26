# Задача 

Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

**Пример:**
```
["hello", "2", "world", ":-)"] -> ["2", ":-)"]
```


>1. Создать репозиторий гитхаб
>2. нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части, если вы выделяете её в отдельный метод)
>3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md)
>4. Написать программу, решающую поставленную задачу
>5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так что все залито одним коммитом, как минимум этапы 2,3 и 4 должны быть расположенны в разных коммитах)

___
___

# ***Решение задачи***
## Этап первый - создание массива генерирующего рандомные строки.
___

![блок-схема](https://github.com/Wredina/Finar_work_program_1/blob/main/%D0%B1%D0%BB%D0%BE%D0%BA-%D1%81%D1%85%D0%B5%D0%BC%D1%8B/%D0%BC%D0%B5%D1%82%D0%BE%D0%B4_%D1%81%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D1%8F_%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2%D0%B0.png?raw=true)

Я не очень люблю без острой необходимости вручную вводить какие-либо данные, мне больше нравится написать программу и что бы она сама мне всё вводила и выводила, а от меня требуется только её запуск. Поэтому мне первоначально понадобится метод, который будет генерировать мне строковый массив рандомной длины, с рандомным кол-вом символов в каждом элементе.
1. Создаём строковый метод и записываем его в переменную, при помощи которой мы сможем дальше передавать или выводить именно этот полученный массив, который он нам сгенерирует.
``` C#
string[] arr = СreationArrString(new Random().Next(4, 8));
```
>Массив в С# долженбыть всегда определённой длины. Что бы он небыл огромным, я его ограничила рандомным выбором от 4 до 7 эл. включительно. Т.е. Мы создаём строковый метод, в параметр которого передаём целочисленный тип длины массива - *sizeArr.*
``` C#
string[] СreationArrString(int sizeArr) {}
```
2. Теперь нужно создать в этом методе массив, который будем наполнять и зададим ему длину, которую передали в параметр.
``` C#
string[] array = new string[sizeArr];
```
3. Что бы у нас была возможность самим создавать строки из рандомных символов, эти символы должны быть у нас где-то записаны. Поэтому создаём новый массив, в который вкладываем, например, алфавит и который имеет длину в 26 символов (длина алфавита). В блок схеме я это указала как ABC и тут тоже.
``` C#
string[] letters = new string[26] {ABC};
```
4. Далее создаём первый цикл для заолнения массива элементами. Этот цикл будет давать длину слов и записывать получаемые слова.
``` c#
for (int j = 0; j < sizeArr; j++)
```
* В нём мы создадим пустую строковую переменную *word* для записи и сброса слова. Т.е мы сначала записываем слово, сохраняем в массив, а потом очищаем переменную для нового слова. 
* Тут же мы создаём целочисленную переменную для хранения рандомной длины слова. Я указала от 1 до 9 включительно, что бы слова небыли сильно длинными.
* Ну и что бы рандом отрабатывал более чисто и точно, я поместила его в отдельную переменную *rnd* переменную.
* Запись слова в наш массив поставлен в самом конце, после вложенного цикла, перед закрытием, что бы переменная в которую записано слово не очистилось раньше, чем запишется в массив.
``` C#
string word = "";
Random rnd = new Random();
int wordSize = rnd.Next(1, 10);
```
5. Создаём ещё одни цикл, вложенный, который будет проходит итерации до указанной длины слова, выцеплять рандомные элементы из алфавита и собирать слово
``` c#
for (int i = 0; i < wordSize; i++){
word += letters[rnd.Next(0, 26)];
}
```
* используем массив с алфавитом, в индексе которого формируется рандомное значение. И тот элемент, который находится под этим индексом, складываем в переменную.

6. **ВАЖНО** Выходим из вложенного цикла и сразу записываем полученное слово в первый индекс массива.
``` c#
array[j] = word;
```
7. Далее происходит новая итерация первого цикла, где увеличивается *j* на единичку, проходим в тело цикла, там переменная word принимает новое пустое значение, далее генерируется новая длина слова и записывается в переменную *wordSize*. И снова проваливаемся во вложенный цикл, где составляется новое слово, после отработки которого, мы записываем его в массив. И это повторяется пока в первом цикле кол-во элементов в массиве не будет равна указанной длине массива.

8. После отработки всех массивов, мы возвращаем наш новоиспечённый массив
``` c#
return array;
```

9. Т.к. мы продукт отработки метода записывали в переменную (пункт 1), то выведем то, что у нас получилось при помощи метода вывода информации в консоль, внутри которого поместим метод, позволяющий переводить информацию массива в строки и выставить межстрочный интервал между элементами массива. 
``` c#
Console.WriteLine(String.Join(", ", arr));
```

## Этап два - поиск длины массива, который будет выводит нужные элементы
___
![длина_нового_массива](https://github.com/Wredina/Finar_work_program_1/blob/main/%D0%B1%D0%BB%D0%BE%D0%BA-%D1%81%D1%85%D0%B5%D0%BC%D1%8B/%D0%BF%D0%BE%D0%B8%D1%81%D0%BA_%D0%B4%D0%BB%D0%B8%D0%BD%D1%8B.png?raw=true)
1. Как говорилось ранее, для создания массива необходимо знать его длину. Наш изначальный массив формируется рандомно по длине и по кол-ву символов в элементах, поэтому чёткого понимания длины нового массива нет. 
Создаём новый метод, который принимает на вход первоначальный массив и будет возвращать число. Это число и будет длиной нового массива. Записываем его в отдельную переменную.
```C#
int sizeMiniArray = SizeForMiniArray(arr);
```

2. В теле этого метода мы создаём переменную, в которую записываем длину нашего уже созданного массива.
```C#
int sizeMiniArr = array.Length;
```

3. Создаём цикл, в теле которого мы ставим условие, по которому будет расчитываться длина нового массива. Т.е. если условие выполняется, то мы будем уменяьшать записанную длину в переменной *sizeMiniArr* на единицу, а если условие не выполняется, то мы длину оставляем такой же.
```C#
for (int i = 0; i < array.Length; i++)
 {
  if (array[i].Length > 3) sizeMiniArr -= 1;
 }
 ```
 > Т.к. нам нужны строки длиной менее или равные 3-м, в условии мы указываем, если длина символов элемента больше трёх, то уменьшаем длину массива на 1.

 Как только цикл отрабатываем, возвращаем новую длину для нашего нового массива.
 ```c#
 return sizeMiniArr;
 ```

 ## Этап третий - проверка
 ___
 Т.к. наш первоначальный массив рандомный по всем параметрам, то может случиться такое, что ни один из элементов не будет соответствовать условию, а значит, вместо пустого поля, лучше вывести сообщение. Поэтому делаем проверку, если длина нового массива равна нулю, то выводим сообщение, что нет подходящих элементов. Иначе - переходим к этапу 4.

 ```c#
 if (sizeMiniArray == 0) System.Console.WriteLine("нет элементов менее 4-х символов");
else
{
 string[] miniArr = CreateNewMiniArrayString(sizeMiniArray, arr);
 Console.WriteLine(String.Join(", ", miniArr));
}
```

 ## Этап четвёртый - формирование массива строк, длина которых меньше или равна 3-м.
___

![новый_массив](https://github.com/Wredina/Finar_work_program_1/blob/main/%D0%B1%D0%BB%D0%BE%D0%BA-%D1%81%D1%85%D0%B5%D0%BC%D1%8B/%D0%BD%D0%BE%D0%B2%D1%8B%D0%B9_%D0%BC%D0%B0%D1%81%D1%81%D0%B8%D0%B2.png?raw=true)
1. Создаём метод, который будет сформировывать новый массив и записываем его в переменную.
В этот метод на вход мы передаём два параметра: другой метод, который находит длину нового массива и первоначальный массив.
```c#
string[] miniArr = CreateNewMiniArrayString(sizeMiniArray, arr);
```
2. В теле этого метода нам понадобится счётчик, что бы когда при переборке элементов первоначального массива, найдётся тот, который подойдёт по условию, мы могли записать его под нужным индексом.
```c#
int j = 0;
```
Так же нам понадобиться создать новый массив, куда будут записываться нужные элементы и задать ему найденную длину.
```c#
string[] miniArr = new string[size];
```
3. Создаём цикл, используя длину первоначального массива. Для заполнения нашего массива, в теле цикла используем условие для поиска подходящих элементов, т.е. если длина элемента из первоначального массива не превышает 3-х символов, то записываем этот элемент в новый массив и повышаем его индекс. Если элемент не подходит, то мы его пропускаем.
```c#
for (int i = 0; i < BigArr.Length; i++)
 {
  if (BigArr[i].Length <= 3)
  {
   miniArr[j] = BigArr[i];
   j++;
  }
 }
 ```

 4. Как только отрабатывает цикл, нужно вернуть наш заполненный новый массив.
 ```C#
 return miniArr;
 ```
5. Ну и что бы вывести в консоль этот массив, воспользуемся методом вывода информации и методом строк Join, который позволит выстроить межстрочные интервалы.
```c#
Console.WriteLine(String.Join(", ", miniArr));
```

## Все схемы
___
![все_схемы](https://github.com/Wredina/Finar_work_program_1/blob/main/%D0%B1%D0%BB%D0%BE%D0%BA-%D1%81%D1%85%D0%B5%D0%BC%D1%8B/%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%D1%8B_%D0%BE%D1%82%D0%B4%D0%B5%D0%BB%D1%8C%D0%BD%D0%BE.png?raw=true)

