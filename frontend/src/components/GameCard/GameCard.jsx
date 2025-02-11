import "./GameCard.css";
import PropTypes from "prop-types";
import {Button} from "../UI/Button/Button.jsx";
import {useNavigate} from "react-router-dom";

export function GameCard({id, username, rating, date, status, ...rest }){
    GameCard.propTypes = {
        id: PropTypes.number.isRequired,
        username: PropTypes.string.isRequired,
        rating: PropTypes.number.isRequired,
        date: PropTypes.string.isRequired,
        status: PropTypes.oneOf(['created', 'started', 'closed']).isRequired,
    }
    const navigate = useNavigate();

    //TODO: сделать реализацию
    const joinGame = () => {
        console.log(`Joining game ${id}`);
        navigate(`game/${id}`)
    }

    return(
        <>
            <div className="game-card" {...rest}>
                <div className="game-sender">
                    <span className="username">{username}</span>
                    <span className="status">status: {status}</span>
                </div>
                <div className="game-data">
                    <span className="game-id">id: {id}</span>
                    <span>Max Rating: {rating}</span>
                    <span className="game-timestamp">{new Date(date).toLocaleString()}</span>
                </div>
                <Button text={"Join"} onClick={joinGame}></Button>
            </div>
        </>
    )
}