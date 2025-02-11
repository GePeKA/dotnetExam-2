import {GameCard} from "../../../components/GameCard/GameCard.jsx";
import {useEffect, useState} from "react";
import {axiosToBackend} from "../../../hooks/useAxios.js";
import {toast} from "react-toastify";
import "./HomePage.css"
import {Banner} from "../../../components/UI/Banner/Banner.jsx";
import {Button} from "../../../components/UI/Button/Button.jsx";
import {CreateGameWindow} from "../../../components/CreateGameWindow/CreateGameWindow.jsx";
import {BestPlayersWindow} from "../../../components/BestPlayersWindow/BestPlayersWindow.jsx";

//TODO: сделать пагинацию
export default function HomePage() {
    const [games, setGames] = useState([
        {id: 1, username:"sex", rating:1, date: '00:00:01 01.02.2023', status: "closed"},
        {id: 2, username:"sex", rating:1, date: '00:01:03 01.02.2023', status: "closed"},
        {id: 3, username:"sex", rating:1, date: '00:00:02 01.02.2023', status: "closed"},
        {id: 4, username:"sex", rating:1, date: '00:00:01 01.02.2023', status: "started"},
        {id: 7, username:"sex", rating:1, date: '00:00:01 01.02.2023', status: "created"},
        {id: 5, username:"sex", rating:1, date: '02:00:03 01.02.2023', status: "closed"},
        {id: 6, username:"sex", rating:1, date: '00:00:02 04.02.2023', status: "closed"}
    ]);
    const [page, setPage] = useState(1);
    const [createGameWindowIsOpen, setCreateGameWindowIsOpen] = useState(false);
    const [bestPlayersWindowIsOpen, setBestPlayersWindowIsOpen] = useState(false);

    const fetchAllGames = async () => {
        try {
            //TODO: заменить ссылку
            const response = await axiosToBackend.get(`/game/get-all/${page}`);
            setGames([...response.data.map(g => ({ id: g.id, username: g.userName,
                rating: g.maxAllowedRating, date: g.dateTimeCreated, status: g.status}))]);
        } catch (error) {
            toast.error(`Game Card: ${error}`, { toastId: "GameCardFetchError" })
        }
    };
    useEffect( () => {
        fetchAllGames();
    }, [page]);

    const sortedGames = games.sort((a, b) => {
        const dateA = new Date(a.date).getTime();
        const dateB = new Date(b.date).getTime();
        if (dateA !== dateB) {
            return dateA - dateB;
        }
        const statusOrder = {
            "created": 0,
            "started": 1,
            "closed": 2
        };
        return statusOrder[a.status] - statusOrder[b.status];
    });

    return (
        <div className="game-list">
            <CreateGameWindow isOpen={createGameWindowIsOpen} onClose={() => setCreateGameWindowIsOpen(false)}/>
            <BestPlayersWindow isOpen={bestPlayersWindowIsOpen} onClose={() => setBestPlayersWindowIsOpen(false)}/>
            <Banner className="game-list-banner">
                <div className="game-list-buttons">
                    <Button text={"Leaders"} onClick={() => setBestPlayersWindowIsOpen(true)} ></Button>
                    <Button text={"Create"} onClick={() => setCreateGameWindowIsOpen(true)}></Button>
                </div>
                {games.length ? sortedGames.map((game, index) => (
                        <GameCard key={index} date={game.date} rating={game.rating} id={game.id} username={game.username} status={game.status}/>)) :
                    <p style={{textAlign: "center", fontWeight: 'bold'}}>No Games</p> }
            </Banner>
        </div>
    )
}