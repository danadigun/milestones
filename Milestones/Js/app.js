var ScreeningController = function ($scope, $http) {

    var serviceUrl = "~/Questionnaire/Create";

    var blankQuestion = {
        Id: "",
        Question:""
    };

    var refreshQuestions = function () {
        $http.get(serviceUrl).success(function (data) {
            $scope.Questions = data;
        });
    };

    $scope.isEditVisible = false;

    $scope.ShowEdit = function () {
        $scope.isEditVisible = true;
        $scope.editableQuestion = angular.copy(blankQuestion);
    };

    $scope.saveQuestionnaire = function () {
        $scope.isEditVisible = false;
        $scope.post(serviceUrl, $scope.editableQuestion)
                .success(function (question) {
                    $scope.Questions.push(question);
                    alert("Saved Successfully!!");
                });
    };
    refreshQuestions();
};