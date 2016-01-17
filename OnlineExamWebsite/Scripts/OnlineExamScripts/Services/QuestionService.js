angular.module("OnlineExam").service("QuestionService",
function ($http) {
    var urlbase = "http://localhost:17012/api/mcqquestions";
    var testURl = "http://localhost:17012/api/mcqquestions/2a2c5345-7c6b-48b9-a7e6-f0200cc01dcf";
    this.GetAllMcqQuestions = function () {
        return $http({
            method: "get",
            url: urlbase
        });
    };

    this.GetMcqQuestionById = function (questionId) {
        return $http(
            {
                method: "get",
                url: urlbase,
                params: {
                    id: questionId
                }
                
            });
    };
    this.AddQuestion = function (mcqQuestion) {
        var response = $http({
            method: "post",
            url: urlbase,
            data: JSON.stringify(mcqQuestion),
            dataType: "json"
        });
        return response;
    };

    this.UpdateQuestion = function (qid,mcqQuestion) {
        var response = $http({
            method: "put",
            url: urlbase,
            data: JSON.stringify(mcqQuestion),
            dataType: "json",
            params:{
            id: qid
        }
        });
        return response;
    }
});