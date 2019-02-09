using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера пользовательского ввода
    /// </summary>
    /// <see cref="IUpdatable"/> <br/>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="BaseModel"/>
    public class InputController : BaseController<BaseModel>, IUpdatable
    {
        /// <summary>
        /// Список команд на исполнение
        /// </summary>
        private List<InputCommand> _commands;

        private string _horizontalAxis = "Horizontal";
        private string _verticalAxis = "Vertical";

        private string _mouseXAxis = "Mouse X";
        private string _mouseYAxis = "Mouse Y";

        public InputController(BaseModel baseModel) : base(baseModel)
        {
            _commands = new List<InputCommand>();
        }

        /// <summary>
        /// Метод, где происходит считывание пользовательского ввода <br/>
        /// После того, как мы обнаружили пользовательский ввод, мы должны из InputCommandFactory достать объект команды/ <br/>
        /// Проинициализировав объект команды, его нужно добавить в список команд на исполнение. <br/>
        /// После этого система сама вернет объект команды в пул, а список команд для исполенния - очистится
        /// </summary>
        /// <param name="deltaTime"></param>
        public void OnUpdate(float deltaTime)
        {
            _commands.Clear();

            var hAxis = Input.GetAxis(_horizontalAxis);
            var vAxis = Input.GetAxis(_verticalAxis);
            var move = InputCommandFactory.GetCommand<PlayerMovementCommand>();
            move.SetHorizontalAndVerticalAxis(hAxis, vAxis);
            _commands.Add(move);

            var xAxis = Input.GetAxis(_mouseXAxis);
            var yAxis = Input.GetAxis(_mouseYAxis);
            var turn = InputCommandFactory.GetCommand<MouseLookCommand>();
            turn.SetHorizontalAndVerticalAxis(xAxis, yAxis);
            _commands.Add(turn);

            for ( var i = 0; i < _commands.Count; i++ ) {
                _commands[i].Execute();
            }
        }
    }
}