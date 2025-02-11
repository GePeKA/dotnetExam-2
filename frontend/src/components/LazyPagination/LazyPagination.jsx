import { useState } from 'react';
import "./LazyPagination.css"
import {Button} from "../UI/Button/Button.jsx";
import ICONS from "../../assets/icons.jsx";

const LazyPagination = ({ totalPages }) => {
    const [currentPage, setCurrentPage] = useState(1);

    const handleNext = () => {
        if (currentPage < totalPages) {
            setCurrentPage(currentPage + 1);
        }
    };

    const handlePrev = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1);
        }
    };

    return (
        <div className={"pagination"}>
            <Button iconPath={ICONS.caret_left} onClick={handlePrev} disabled={currentPage === 1}>
                ← Назад
            </Button>
            <span style={{font: "Syne"}}>Страница {currentPage} из {totalPages}</span>
            <Button iconPath={ICONS.caret_right} onClick={handleNext} disabled={currentPage === totalPages}>
                Вперед →
            </Button>
        </div>
    );
};

export default LazyPagination;
