angular.module("OnlineExam").controller("QuestionController",
    function ($scope, QuestionService) {

        $scope.divQuestionList = true;
        GetAllMcqQuestions();

        $scope.divCreateQuestion = false;
        $scope.CreateQuestionDiv = function () {
            $scope.divCreateQuestion = true;
        };

        $scope.abcd = ['A', 'B', 'C', 'D'];
        $scope.correctAnswer = [false,false,false,false];
        $scope.setAnswer = function (i) {
            for (var n = 0; n < 4;n++)
                $scope.correctAnswer[n] = false;
            $scope.correctAnswer[i] = true;
            $scope.ca = $scope.abcd[i];
        };
        

        $scope.AddQuestion = function () {
            var McqQuestion = {
                SubjectCode: $scope.subjectCode,
                DifficultyLevel: $scope.difficultyLevel,
                Class: $scope.class,
                QuestionText: $scope.questionText,
                OptionA: $scope.optionA,
                OptionB: $scope.optionB,
                OptionC: $scope.optionC,
                OptionD: $scope.optionC,
                CorrectAnswer: $scope.ca
            };
            var getQuestionData = QuestionService.AddQuestion(McqQuestion);

            getQuestionData.then(function (msg) {
                alert(msg.data);
                $scope.divCreateQuestion = false;
                $scope.ClearFields();
            },
            function () {
                alert("Error in adding question!");
            });

        }

        function GetAllMcqQuestions() {
            var GetMcqQuestionsData = QuestionService.GetAllMcqQuestions();
            GetMcqQuestionsData.then(function (questions) {
                $scope.mcqQuestions = questions.data;
            }, function () {
                alert("Error getting contact data");
            });

        }



        $scope.ClearFields = function () {
            $scope.questionText = "";
            $scope.optionA = "";
            $scope.optionB = "";
            $scope.optionC = "";
            $scope.optionD = "";
            $scope.ca = false;
        }
    });