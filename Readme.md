## Найденные паттерны:
###### 1 TEMPLATE METHOD
где:
- ReportServiceTransformerBase - AbstractClass,
- CostSumReportTransformer, CountSumReportTransformer и т.д. - ConcreteClass
- А TransformDate - TemplateMethod

###### 2 DECORATOR
где:
- IDataTransformer - компонент,
- DataTransformer - конкретная реализация компонента
- WithDataReportTransformer, VolumeSumReportTransformer... - конкретные декораторы,
- ReportServiceTransformerBase - декоратор 

###### 3 STRATEGY
Выбор реализации IReportService можно назвать стратегией (изначально было в Progrem в GetReportService)

###### 4 FACTORY METHOD
1 метод GetReportService в Program (до изменений)
2 метод CreateTransformer в DataTransformerCreator

## Реализованные паттерны:
1 BUILDER  ReportPrinterBuilder
Зачем?
- ссылаюсь на презентацию: "Алгоритм создания сложного объекта не должен зависеть от того, из каких частей
состоит объект и как они стыкуются между собой"

2 CHAIN OF RESPONOBILITY
Зачем?
- ссылаясь на первый пункт из легенды "Через неделю поступит точная постановка по внедрению работы с
2-мя новыми расширениями файлов" т.к. 5 - это уже много то - ссылаясь на презентацию "Имеется большое кол-во различных обработчиков и заранее не известно какой из
них должен обработать запрос"

## Предложения по внедрению паттернов:
- 1 В моей голове мысли о том, что если бы программа надо количеством файлов > 1, то можно было бы сделать IReportService-ы синглтонами, с аргументами в таком случае можно поступить по разному, либо одни на все файлы, либо вынести из конструктора сервисов.
