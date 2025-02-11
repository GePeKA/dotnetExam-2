import {useState} from "react";
import "./GamePage.css"
import ICONS from "../../../assets/icons.jsx";
import {Button} from "../../../components/UI/Button/Button.jsx";
import {Banner} from "../../../components/UI/Banner/Banner.jsx";
import {Icon} from "../../../components/UI/Icon/Icon.jsx";
import {useParams} from "react-router-dom";

export default function GamePage() {
    const [board, setBoard] = useState(Array(9).fill(null));
    const [isXNext, setIsXNext] = useState(true);
    const { id } = useParams()
    const handleClick = (index) => {
        if (board[index] || calculateWinner(board)) return;

        const newBoard = board.slice();
        newBoard[index] = isXNext ? 'X' : 'O';
        setBoard(newBoard);
        setIsXNext(!isXNext);
    };

    const calculateWinner = (squares) => {
        const lines = [
            [0, 1, 2],
            [3, 4, 5],
            [6, 7, 8],
            [0, 3, 6],
            [1, 4, 7],
            [2, 5, 8],
            [0, 4, 8],
            [2, 4, 6],
        ];
        for (let i = 0; i < lines.length; i++) {
            const [a, b, c] = lines[i];
            if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
                return squares[a];
            }
        }
        return null;
    };

    const winner = calculateWinner(board);
    const status = winner ? `Победитель: ${winner}` : `Следующий ход: ${isXNext ? 'X' : 'O'}`;

    return (
        <div className="game-container">
            <Banner className={"game-banner"}>
                <div className="status">{status}</div>
                <div className="board">
                    {board.map((square, index) => (
                        <button key={index} className="square" onClick={() => handleClick(index)}>
                            {square === 'X' ? <Icon path={ICONS.cross} alt={"X"} width={"100"}/> : square === 'O' ?
                                <Icon path={ICONS.circle} alt={"O"} width={"65"}/> : null}
                        </button>
                    ))}
                </div>
                <Button className="reset" text={"Сбросить игру"} onClick={() => setBoard(Array(9).fill(null))}/>
            </Banner>
        </div>
    );
};
