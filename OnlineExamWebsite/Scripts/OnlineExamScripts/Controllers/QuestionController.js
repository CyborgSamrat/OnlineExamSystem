angular.module("OnlineExam").controller("QuestionController",
    function ($scope, QuestionService) {

        $scope.divQuestionList = true;
        GetAllMcqQuestions();

        

        $scope.divCreateQuestion = false;
        $scope.CreateQuestionDiv = function () {
            $scope.divCreateQuestion = true;
        };

        $scope.EditQuestionDiv = function (questionId) {
            $scope.divCreateQuestion = true;
            $scope.divQuestionList = false;
            GetMcqQuestionById(questionId);
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
                OptionD: $scope.optionD,
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
            $scope.divQuestionList = true;

        }

        function GetAllMcqQuestions() {
            var GetMcqQuestionsData = QuestionService.GetAllMcqQuestions();
            GetMcqQuestionsData.then(function (questions) {
                $scope.mcqQuestions = questions.data;
            }, function () {
                alert("Error getting contact data");
            });

        }

        function GetMcqQuestionById(questionId) {
            var getMcqQuestionData = QuestionService.GetMcqQuestionById(questionId);
            getMcqQuestionData.then(function (question) {
                var mcqQuestion = question.data;
                $scope.mcqQuestionId = mcqQuestion.McqQuestionId;
                $scope.questionText = mcqQuestion.QuestionText;
                $scope.subjectCode = mcqQuestion.SubjectCode;
                $scope.difficultyLevel = mcqQuestion.DifficultyLevel;
                $scope.class = mcqQuestion.Class;
                $scope.optionA = mcqQuestion.OptionA;
                $scope.optionB = mcqQuestion.OptionB;
                $scope.optionC = mcqQuestion.OptionC;
                $scope.optionD = mcqQuestion.OptionD;
                var ca = mcqQuestion.CorrectAnswer;
                switch (ca) {
                    case "A": $scope.setAnswer(0); break;
                    case "B": $scope.setAnswer(1); break;
                    case "C": $scope.setAnswer(2); break;
                    case "D": $scope.setAnswer(3); break;
                }
            }, function () {
                alert("Error geting question....");
            });
        }

        $scope.UpdateQuestion = function(){
            var McqQuestion = {
                McqQuestionId: $scope.mcqQuestionId,
                SubjectCode: $scope.subjectCode,
                DifficultyLevel: $scope.difficultyLevel,
                Class: $scope.class,
                QuestionText: $scope.questionText,
                OptionA: $scope.optionA,
                OptionB: $scope.optionB,
                OptionC: $scope.optionC,
                OptionD: $scope.optionD,
                CorrectAnswer: $scope.ca
            };
            var getQuestionData = QuestionService.UpdateQuestion($mcqQuestionId,McqQuestion);

            getQuestionData.then(function (msg) {
                alert(msg.data);
                $scope.divEditQuestion = false;
                $scope.ClearFields();
            },
            function () {
                alert("Error in updating question!");
            });
            $scope.divQuestionList = true;
        };


        function ClearFields() {
            $scope.questionText = "";
            $scope.optionA = "";
            $scope.optionB = "";
            $scope.optionC = "";
            $scope.optionD = "";
            $scope.ca = false;
        }
    });